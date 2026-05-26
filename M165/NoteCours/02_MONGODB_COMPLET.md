# 🍃 MONGODB - GUIDE COMPLET

---

## C'EST QUOI MONGODB ?

### **Explication Enfant**

Imagine une **boîte à chaussettes** :

**Base de Données Relationelle (SQL):**
```
┌─ Chaussette ─────────────┐
│ ID: 1                     │
│ Couleur: Noir             │
│ Taille: 42                │
│ Matière: Coton            │
│ Année d'achat: 2024       │
│ Elasticité: Bonne         │
└───────────────────────────┘

TOUS les chaussettes ont EXACTEMENT les mêmes informations
Si tu veux ajouter "Odeur", tu dois modifier TOUTES les chaussettes
```

**MongoDB (NoSQL):**
```
Chaussette 1:
{
  id: 1,
  couleur: "noir",
  taille: 42
}

Chaussette 2:
{
  id: 2,
  couleur: "bleu",
  taille: 43,
  motif: "rayures"  ← Différent!
}

Chaussette 3:
{
  id: 3,
  couleur: "rouge",
  marque: "Nike",  ← Aussi différent!
  prix: 5.99
}

Chaque chaussette peut avoir des infos DIFFÉRENTES!
C'est flexible!
```

### **Définition Technique**

```
MongoDB = Document-oriented NoSQL Database

Documents = Collections d'objets JSON
Collections = Groupes de documents
Database = Groupe de collections

Structure:
Database
  └─ Collection "users"
      ├─ Document 1 (JSON)
      ├─ Document 2 (JSON)
      └─ Document 3 (JSON)
  └─ Collection "orders"
      ├─ Document 1 (JSON)
      └─ Document 2 (JSON)
```

---

## 📦 DOCUMENTS ET COLLECTIONS

### **Un Document MongoDB**

```json
{
  "_id": ObjectId("507f1f77bcf86cd799439011"),
  "name": "John Doe",
  "email": "john@example.com",
  "age": 30,
  "isActive": true,
  "address": {
    "street": "123 Main St",
    "city": "Paris",
    "postalCode": "75001"
  },
  "hobbies": ["gaming", "reading", "hiking"],
  "createdAt": ISODate("2024-01-15T10:30:00Z"),
  "metadata": {
    "lastLogin": ISODate("2024-12-20T14:22:00Z"),
    "loginCount": 42
  }
}
```

**Observations:**

```
_id: ObjectId (obligatoire, généré automatiquement)
    - Unique pour chaque document
    - Contient timestamp (quand créé)
    - Si tu ne l'ajoutes pas, MongoDB le crée

Types de données supportés:
✓ Strings ("John")
✓ Numbers (30, 3.14)
✓ Booleans (true, false)
✓ Date (ISODate("2024-01-15..."))
✓ Arrays (["gaming", "reading"])
✓ Objects (address: { street: "...", city: "..." })
✓ null
✓ ObjectId (pour les références)
✓ Binary data
✓ etc.

Pas de schéma rigide:
- Chaque document peut avoir des champs différents
- Aucun problème si un doc n'a pas le champ "age"
- Très flexible
```

### **Collection MongoDB**

```javascript
// Une collection = group de documents similaires
db.users.find()  // Tous les users

// Mais les documents peuvent être différents!
[
  { _id: 1, name: "John", age: 30 },
  { _id: 2, name: "Alice", age: 25, city: "London" },
  { _id: 3, name: "Bob", email: "bob@ex.com" }
]

// C'est OK! MongoDB accepte
```

---

## 🎯 OPÉRATIONS CRUD EN MONGODB

### **C - CREATE (Insérer des données)**

#### **Insérer UN document**

```javascript
// Syntaxe MongoDB
db.users.insertOne({
  name: "John Doe",
  email: "john@example.com",
  age: 30
})

// Résultat:
{ acknowledged: true, insertedId: ObjectId("...") }
```

#### **Insérer PLUSIEURS documents**

```javascript
db.users.insertMany([
  { name: "John", email: "john@example.com", age: 30 },
  { name: "Alice", email: "alice@example.com", age: 25 },
  { name: "Bob", email: "bob@example.com", age: 35 }
])

// Résultat:
{
  acknowledged: true,
  insertedIds: [ObjectId("..."), ObjectId("..."), ObjectId("...")]
}
```

### **R - READ (Lire des données)**

#### **Trouver UN document**

```javascript
db.users.findOne({ email: "john@example.com" })

// Résultat:
{
  _id: ObjectId("507f1f77bcf86cd799439011"),
  name: "John Doe",
  email: "john@example.com",
  age: 30
}
```

#### **Trouver TOUS les documents**

```javascript
db.users.find()

// Résultat: Tous les users
[
  { _id: ..., name: "John", email: "john@example.com", age: 30 },
  { _id: ..., name: "Alice", email: "alice@example.com", age: 25 },
  ...
]
```

#### **Trouver avec FILTRES**

```javascript
// Condition simple
db.users.find({ age: 30 })

// Condition complexe
db.users.find({
  age: { $gt: 25 },  // Greater Than (>)
  isActive: true
})

// Opérateurs disponibles:
$eq    // Equal (=)
$ne    // Not Equal (!=)
$gt    // Greater Than (>)
$gte   // Greater or Equal (>=)
$lt    // Less Than (<)
$lte   // Less or Equal (<=)
$in    // IN (value in list)
$nin   // NOT IN

// Exemples:
db.users.find({ age: { $gt: 25 } })           // age > 25
db.users.find({ age: { $gte: 25, $lte: 35 } }) // 25 <= age <= 35
db.users.find({ city: { $in: ["Paris", "London"] } }) // city in list
```

#### **Projection: Ne récupérer que certains champs**

```javascript
// Récupère seulement name et email (pas age)
db.users.find({}, { name: 1, email: 1 })

// Récupère tout SAUF age
db.users.find({}, { age: 0 })

// _id est toujours inclus sauf si:
db.users.find({}, { name: 1, _id: 0 })
```

#### **Sort et Limit**

```javascript
// Trier par age (ascendant: 1)
db.users.find().sort({ age: 1 })

// Trier par age (descendant: -1)
db.users.find().sort({ age: -1 })

// Seulement les 5 premiers
db.users.find().limit(5)

// Sauter les 10 premiers (pagination!)
db.users.find().skip(10).limit(5)  // users 11-15

// Combinaison:
db.users.find()
  .sort({ age: -1 })
  .skip(10)
  .limit(5)
```

### **U - UPDATE (Mettre à jour)**

#### **Mettre à jour UN document**

```javascript
// Change l'email pour John
db.users.updateOne(
  { name: "John" },           // Condition: qui modifier?
  { $set: { email: "newemail@example.com" } }  // Quoi modifier?
)

// Résultat:
{ matchedCount: 1, modifiedCount: 1 }
```

#### **Mettre à jour PLUSIEURS documents**

```javascript
// Augmente l'age de 1 pour TOUS les users
db.users.updateMany(
  {},  // Condition: TOUS (pas de filtre)
  { $inc: { age: 1 } }  // Opération: incrémenter age
)

// Résultat:
{ matchedCount: 42, modifiedCount: 42 }
```

#### **Opérateurs de modification**

```javascript
// $set: Change la valeur
db.users.updateOne(
  { _id: 1 },
  { $set: { age: 31, city: "London" } }
)

// $inc: Incrémenter/décrémenter
db.users.updateOne(
  { _id: 1 },
  { $inc: { age: 1 } }  // age = age + 1
)

// $push: Ajouter à un array
db.users.updateOne(
  { _id: 1 },
  { $push: { hobbies: "cooking" } }
)

// $pull: Retirer d'un array
db.users.updateOne(
  { _id: 1 },
  { $pull: { hobbies: "gaming" } }
)

// $unset: Supprimer un champ
db.users.updateOne(
  { _id: 1 },
  { $unset: { age: "" } }  // Le champ age disparaît
)

// $currentDate: Mettre à jour avec la date actuelle
db.users.updateOne(
  { _id: 1 },
  { $currentDate: { lastModified: true } }
)
```

### **D - DELETE (Supprimer)**

#### **Supprimer UN document**

```javascript
db.users.deleteOne({ name: "John" })

// Résultat:
{ deletedCount: 1 }
```

#### **Supprimer PLUSIEURS documents**

```javascript
db.users.deleteMany({ age: { $gt: 100 } })

// Résultat:
{ deletedCount: 3 }
```

---

## 🔍 REQUÊTES AVANCÉES: AGGREGATION PIPELINE

### **C'est Quoi ?**

L'aggregation pipeline = **transformer et analyser les données** en plusieurs étapes.

```
Données brutes
    ↓ Stage 1: $match (filtrer)
    ↓ Stage 2: $group (grouper)
    ↓ Stage 3: $sort (trier)
    ↓
Résultat final analysé
```

C'est comme un **tuyau** où les données passent par plusieurs traitements.

### **Exemple 1: Simple (Exemple du cours)**

```javascript
// Données dans collection "orders":
[
  { _id: 0, name: "Pepperoni", size: "small", price: 19, quantity: 10 },
  { _id: 1, name: "Pepperoni", size: "medium", price: 20, quantity: 20 },
  { _id: 2, name: "Pepperoni", size: "large", price: 21, quantity: 30 },
  { _id: 3, name: "Cheese", size: "small", price: 12, quantity: 15 },
  { _id: 4, name: "Cheese", size: "medium", price: 13, quantity: 50 },
  { _id: 5, name: "Cheese", size: "large", price: 14, quantity: 10 },
  { _id: 6, name: "Vegan", size: "small", price: 17, quantity: 10 },
  { _id: 7, name: "Vegan", size: "medium", price: 18, quantity: 10 }
]

// REQUÊTE: Grouper par nom et calculer quantité totale pour les tailles "medium"
db.orders.aggregate([
  // Stage 1: Filtrer (garder seulement tailles "medium")
  {
    $match: { size: "medium" }
  },
  // Stage 2: Grouper par nom et sommer les quantités
  {
    $group: {
      _id: "$name",                    // Grouper par champ "name"
      totalQuantity: { $sum: "$quantity" }  // Sommer les quantités
    }
  }
])

// RÉSULTAT:
[
  { _id: "Cheese", totalQuantity: 50 },
  { _id: "Vegan", totalQuantity: 10 },
  { _id: "Pepperoni", totalQuantity: 20 }
]

// Explication:
// 1. $match filtre: Garder SEULEMENT:
//    - { _id: 1, name: "Pepperoni", size: "medium", qty: 20 }
//    - { _id: 4, name: "Cheese", size: "medium", qty: 50 }
//    - { _id: 7, name: "Vegan", size: "medium", qty: 10 }
//
// 2. $group regroupe par "name" et somme:
//    Pepperoni: 20
//    Cheese: 50
//    Vegan: 10
```

### **Exemple 2: Complexe (Exemple du cours)**

```javascript
// REQUÊTE: 
// 1. Filtrer par plage de dates
// 2. Grouper par jour
// 3. Calculer valeur totale et moyenne de quantité
// 4. Trier par valeur décroissante

db.orders.aggregate([
  // Stage 1: Filtrer par dates
  {
    $match: {
      date: {
        $gte: ISODate("2021-01-13"),
        $lt: ISODate("2021-03-14")
      }
    }
  },
  
  // Stage 2: Grouper par jour et calculer
  {
    $group: {
      _id: { $dateToString: { format: "%Y-%m-%d", date: "$date" } },
      totalOrderValue: {
        $sum: { $multiply: ["$price", "$quantity"] }  // price × quantity
      },
      averageOrderQuantity: { $avg: "$quantity" }
    }
  },
  
  // Stage 3: Trier par valeur totale décroissante
  {
    $sort: { totalOrderValue: -1 }
  }
])

// RÉSULTAT:
[
  {
    _id: "2021-03-13",
    totalOrderValue: 770,
    averageOrderQuantity: 15
  },
  {
    _id: "2021-01-13",
    totalOrderValue: 350,
    averageOrderQuantity: 10
  }
]

// Explication étape par étape:
// 1. $match: Garder seulement les commandes entre 2021-01-13 et 2021-03-14
//    4 documents restent
//
// 2. $group par jour:
//    - "2021-03-13": Pepperoni(20×20=400) + Cheese(13×15=195) + Pepperoni(21×30=630) = 770
//    - "2021-01-13": Vegan(18×10=180) + Vegan(17×10=170) = 350
//    - Moyennes de quantité calculées aussi
//
// 3. $sort: Trier par totalOrderValue décroissant (-1)
```

### **Les Étapes (Stages) Principales**

```javascript
// $match: Filtrer documents (comme WHERE en SQL)
{ $match: { age: { $gt: 25 } } }

// $group: Grouper et faire des calculs
{ $group: { _id: "$city", count: { $sum: 1 } } }

// $sort: Trier
{ $sort: { age: -1 } }

// $limit: Prendre N documents
{ $limit: 10 }

// $skip: Sauter N documents
{ $skip: 5 }

// $project: Sélectionner/modifier champs
{ $project: { name: 1, age: 1, _id: 0 } }

// $lookup: JOIN avec autre collection (SQL JOIN)
{
  $lookup: {
    from: "orders",
    localField: "_id",
    foreignField: "userId",
    as: "userOrders"
  }
}

// $unwind: Déployer un array en documents
{ $unwind: "$hobbies" }

// $addFields: Ajouter des champs calculés
{ $addFields: { fullName: { $concat: ["$firstName", " ", "$lastName"] } } }

// $count: Compter les documents
{ $count: "totalUsers" }
```

### **Opérateurs dans $group**

```javascript
// $sum: Sommer les valeurs
{ $group: { _id: "$type", total: { $sum: "$price" } } }

// $avg: Moyenne
{ $group: { _id: "$type", average: { $avg: "$price" } } }

// $min: Minimum
{ $group: { _id: "$type", lowest: { $min: "$price" } } }

// $max: Maximum
{ $group: { _id: "$type", highest: { $max: "$price" } } }

// $count: Compter (dépréciée, utilise $sum: 1)
{ $group: { _id: "$type", count: { $sum: 1 } } }

// $push: Créer un array
{ $group: { _id: "$type", names: { $push: "$name" } } }

// $addToSet: Créer un array sans doublons
{ $group: { _id: "$type", uniqueNames: { $addToSet: "$name" } } }

// $first: Première valeur du groupe
{ $group: { _id: "$type", firstName: { $first: "$name" } } }

// $last: Dernière valeur du groupe
{ $group: { _id: "$type", lastName: { $last: "$name" } } }
```

---

## 💻 MONGODB AVEC C#

### **Installation et Configuration**

```csharp
// 1. Installer le NuGet Package
// dotnet add package MongoDB.Driver

using MongoDB.Driver;
using MongoDB.Bson;

// 2. Créer la connexion
string connectionString = "mongodb://localhost:27017";
MongoClient client = new MongoClient(connectionString);

// 3. Accéder à la base de données
IMongoDatabase database = client.GetDatabase("myAppDb");

// 4. Accéder à une collection
IMongoCollection<BsonDocument> collection = 
    database.GetCollection<BsonDocument>("users");
```

### **CREATE - Insérer avec C#**

```csharp
// Insérer UN document
var user = new BsonDocument
{
    { "name", "John Doe" },
    { "email", "john@example.com" },
    { "age", 30 }
};
await collection.InsertOneAsync(user);
```

```csharp
// Insérer PLUSIEURS documents
var users = new List<BsonDocument>
{
    new BsonDocument
    {
        { "name", "John" },
        { "email", "john@example.com" },
        { "age", 30 }
    },
    new BsonDocument
    {
        { "name", "Alice" },
        { "email", "alice@example.com" },
        { "age", 25 }
    }
};
await collection.InsertManyAsync(users);
```

### **READ - Lire avec C#**

```csharp
// Trouver UN document
var filter = Builders<BsonDocument>.Filter.Eq("email", "john@example.com");
var user = await collection.Find(filter).FirstOrDefaultAsync();

// Afficher les résultats
if (user != null)
{
    Console.WriteLine(user.ToString());
}
```

```csharp
// Trouver TOUS les documents
var allUsers = await collection.Find(_ => true).ToListAsync();
foreach (var user in allUsers)
{
    Console.WriteLine(user["name"]);
}
```

```csharp
// Trouver avec filtres complexes
var filterBuilder = Builders<BsonDocument>.Filter;

// age > 25 AND isActive = true
var complexFilter = filterBuilder.And(
    filterBuilder.Gt("age", 25),
    filterBuilder.Eq("isActive", true)
);

var results = await collection.Find(complexFilter).ToListAsync();
```

### **Aggregation Pipeline avec C#**

```csharp
// Exemple 1: Simple
var pipeline = new BsonDocument[]
{
    // Stage 1: Match (filtrer)
    new BsonDocument("$match", 
        new BsonDocument("size", "medium")
    ),
    
    // Stage 2: Group (grouper et sommer)
    new BsonDocument("$group",
        new BsonDocument
        {
            { "_id", "$name" },
            { "totalQuantity", new BsonDocument("$sum", "$quantity") }
        }
    )
};

IAsyncCursor<BsonDocument> cursor = 
    await collection.AggregateAsync<BsonDocument>(pipeline);
List<BsonDocument> results = await cursor.ToListAsync();

foreach (var doc in results)
{
    Console.WriteLine($"Pizza: {doc["_id"]}, Quantité: {doc["totalQuantity"]}");
}
```

```csharp
// Exemple 2: Complexe avec dates
DateTime startDate = new DateTime(2021, 1, 13);
DateTime endDate = new DateTime(2021, 3, 14);

var dateFilter = new BsonDocument
{
    { "$gte", startDate },
    { "$lt", endDate }
};

var pipeline = new BsonDocument[]
{
    // Stage 1: Match (filtrer par dates)
    new BsonDocument("$match",
        new BsonDocument("date", dateFilter)
    ),
    
    // Stage 2: Group (grouper par jour et calculer)
    new BsonDocument("$group",
        new BsonDocument
        {
            {
                "_id",
                new BsonDocument("$dateToString",
                    new BsonDocument
                    {
                        { "format", "%Y-%m-%d" },
                        { "date", "$date" }
                    }
                )
            },
            {
                "totalOrderValue",
                new BsonDocument("$sum",
                    new BsonDocument("$multiply",
                        new BsonArray { "$price", "$quantity" }
                    )
                )
            },
            {
                "averageOrderQuantity",
                new BsonDocument("$avg", "$quantity")
            }
        }
    ),
    
    // Stage 3: Sort (trier décroissant)
    new BsonDocument("$sort",
        new BsonDocument("totalOrderValue", -1)
    )
};

IAsyncCursor<BsonDocument> cursor = 
    await collection.AggregateAsync<BsonDocument>(pipeline);
List<BsonDocument> results = await cursor.ToListAsync();

foreach (var doc in results)
{
    Console.WriteLine($"Date: {doc["_id"]}, " +
                     $"Valeur: {doc["totalOrderValue"]}, " +
                     $"Moyenne quantité: {doc["averageOrderQuantity"]}");
}
```

### **UPDATE avec C#**

```csharp
// Mettre à jour UN document
var filter = Builders<BsonDocument>.Filter.Eq("name", "John");
var update = Builders<BsonDocument>.Update
    .Set("email", "newemail@example.com")
    .Inc("age", 1);

var result = await collection.UpdateOneAsync(filter, update);
Console.WriteLine($"Documents modifiés: {result.ModifiedCount}");
```

### **DELETE avec C#**

```csharp
// Supprimer UN document
var filter = Builders<BsonDocument>.Filter.Eq("name", "John");
var result = await collection.DeleteOneAsync(filter);
Console.WriteLine($"Documents supprimés: {result.DeletedCount}");
```

---

## 📡 RÉPLICATION AVEC MONGODB

### **Replica Set**

```
MongoDB Replica Set = 3 serveurs (ou plus)
dont 1 PRIMARY et 2+ SECONDAIRES
```

```javascript
// Configuration du replica set
// mongod --replSet rep1 (sur serveur 1)
// mongod --replSet rep1 (sur serveur 2)
// mongod --replSet rep1 (sur serveur 3)

// Initialiser:
rs.initiate({
  _id: "rep1",
  members: [
    { _id: 0, host: "server1:27017" },
    { _id: 1, host: "server2:27017" },
    { _id: 2, host: "server3:27017" }
  ]
})
```

### **Connexion au Replica Set avec C#**

```csharp
string connectionString = 
    "mongodb://server1:27017,server2:27017,server3:27017/?replicaSet=rep1";

MongoClient client = new MongoClient(connectionString);
IMongoDatabase database = client.GetDatabase("myAppDb");
IMongoCollection<BsonDocument> collection = 
    database.GetCollection<BsonDocument>("users");

// Les écritures vont toujours au PRIMARY
// Les lectures peuvent être distribuées aux SECONDAIRES (optionnel)
```

---

Fin Partie 2 - MongoDB

Prêt pour ArangoDB ? 🚀
