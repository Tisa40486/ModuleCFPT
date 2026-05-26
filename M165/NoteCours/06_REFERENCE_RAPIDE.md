# 📋 RÉFÉRENCE RAPIDE - À GARDER SOUS LA MAIN

---

## MONGODB QUICK REFERENCE

### **Connection (C#)**

```csharp
var client = new MongoClient("mongodb://localhost:27017");
var db = client.GetDatabase("myDb");
var collection = db.GetCollection<BsonDocument>("users");
```

### **CRUD Basics**

```csharp
// CREATE
await collection.InsertOneAsync(new BsonDocument { { "name", "John" } });

// READ
var result = await collection.FindAsync(new BsonDocument { { "age", new BsonDocument { { "$gt", 25 } } } });
var list = await result.ToListAsync();

// UPDATE
var update = Builders<BsonDocument>.Update.Set("age", 31);
await collection.UpdateOneAsync(filterDoc, update);

// DELETE
await collection.DeleteOneAsync(new BsonDocument { { "name", "John" } });
```

### **Query Operators**

| Operator | Meaning | Example |
|----------|---------|---------|
| $eq | Equal | { age: { $eq: 30 } } |
| $ne | Not equal | { age: { $ne: 30 } } |
| $gt | > | { age: { $gt: 25 } } |
| $gte | >= | { age: { $gte: 25 } } |
| $lt | < | { age: { $lt: 35 } } |
| $lte | <= | { age: { $lte: 35 } } |
| $in | In list | { city: { $in: ["Paris", "London"] } } |
| $and | AND | { $and: [{ age: > 25 }, { city: "Paris" }] } |
| $or | OR | { $or: [{ age: > 50 }, { isVIP: true }] } |

### **Aggregation Operators**

| Operator | Purpose |
|----------|---------|
| $match | Filter (WHERE) |
| $group | Group data |
| $sort | Sort results |
| $limit | Limit rows |
| $skip | Skip rows |
| $project | Select fields |
| $lookup | JOIN |
| $unwind | Expand arrays |

### **Group Aggregators**

```javascript
{ $sum: 1 }           // Count
{ $sum: "$price" }    // Sum price
{ $avg: "$quantity" } // Average
{ $min: "$price" }    // Minimum
{ $max: "$price" }    // Maximum
{ $push: "$name" }    // Array of values
{ $addToSet: "$name" } // Array unique values
```

---

## ARANGODB QUICK REFERENCE

### **Connection (JavaScript)**

```javascript
const db = new Database({ url: "http://localhost:8529" });
db.useBasicAuth("root", "password");
db.useDatabase("myDb");

const users = db.collection("users");
```

### **Basic AQL**

```javascript
// SELECT all
FOR user IN users RETURN user

// WHERE
FOR user IN users FILTER user.age > 25 RETURN user

// SELECT specific fields
FOR user IN users RETURN { name: user.name, age: user.age }

// ORDER BY
FOR user IN users RETURN user ORDER BY user.age DESC

// LIMIT
FOR user IN users LIMIT 5 RETURN user
```

### **Insert/Update/Delete**

```javascript
// INSERT
INSERT { _key: "alice", name: "Alice", age: 28 } INTO users

// UPDATE
UPDATE { _key: "alice" } WITH { age: 29 } IN users

// DELETE
REMOVE { _key: "alice" } IN users
```

### **Graph Traversal**

```javascript
// OUTBOUND (suivre edges)
FOR vertex IN 1..1 OUTBOUND "users/alice" GRAPH "social"
  RETURN vertex

// INBOUND (inverse)
FOR vertex IN 1..1 INBOUND "users/alice" GRAPH "social"
  RETURN vertex

// Distance 2 (amis d'amis)
FOR vertex IN 2..2 OUTBOUND "users/alice" GRAPH "social"
  RETURN vertex

// Infinite depth
FOR vertex IN 1..99 OUTBOUND "users/alice" FOLLOW follows
  RETURN vertex
```

---

## MONGODB vs ARANGODB - SIDE BY SIDE

### **"Obtenir tous les utilisateurs > 25 ans"**

**MongoDB**

```javascript
db.users.find({ age: { $gt: 25 } })
```

**ArangoDB**

```javascript
FOR user IN users FILTER user.age > 25 RETURN user
```

---

### **"Compter combien d'utilisateurs par ville"**

**MongoDB**

```javascript
db.users.aggregate([
  {
    $group: {
      _id: "$city",
      count: { $sum: 1 }
    }
  }
])
```

**ArangoDB**

```javascript
FOR user IN users
  COLLECT city = user.city WITH COUNT INTO count
  RETURN { city: city, count: count }
```

---

### **"Trouver tous les followers d'Alice"**

**MongoDB**

```javascript
// Deux collections: users et follows
// Compliqué: faut joindre manuellement

db.follows.find({ to: "alice" })
  // Puis pour chaque résultat, chercher le user
```

**ArangoDB**

```javascript
FOR edge IN follows
  FILTER edge._to == "users/alice"
  FOR user IN users
    FILTER user._id == edge._from
    RETURN user
    
// Ou plus simple:
FOR vertex IN 1..1 INBOUND "users/alice" GRAPH "social"
  RETURN vertex
```

---

## CAP THEOREM DECISION TREE

```
La partition réseau vous inquiète ?

    NON → Utilisez CA (SQL classique, PostgreSQL)
    
    OUI → Vous prioritarisez quoi ?
          
          COHÉRENCE → CP (MongoDB, HBase)
          DISPONIBILITÉ → AP (Cassandra, DynamoDB, Riak)
```

---

## INDEX DECISION TREE

```
Vous faites des FILTER/WHERE dessus ?

    OUI → Index B-Tree (type par défaut)
    
Non, c'est seulement pour EXACT MATCH ?

    OUI → Index Hash
    
C'est pour FULL TEXT SEARCH ?

    OUI → Full-Text Index
    
C'est pour GÉOLOCALISATION ?

    OUI → Spatial Index (Geohash)
    
Plusieurs colonnes ensemble ?

    OUI → Compound Index (ordre importe)
```

---

## AGGREGATION PIPELINE TEMPLATE

```javascript
db.collection.aggregate([
  // Stage 1: Filter (like WHERE)
  {
    $match: { /* conditions */ }
  },
  
  // Stage 2: Transform/Group
  {
    $group: {
      _id: "$fieldToGroupBy",
      count: { $sum: 1 },
      total: { $sum: "$amount" },
      avg: { $avg: "$value" }
    }
  },
  
  // Stage 3: Sort
  {
    $sort: { total: -1 }  // -1 = descending
  },
  
  // Stage 4: Limit results
  {
    $limit: 10
  }
])
```

---

## AQL GRAPH TRAVERSAL TEMPLATE

```javascript
FOR vertex, edge, path IN depth_min..depth_max
  OUTBOUND startVertex  // or INBOUND or ANY
  GRAPH "graphName"
  FILTER /* conditions */
  RETURN {
    vertex: vertex,
    distance: LENGTH(path.edges)
  }
```

---

## COMMON MISTAKES TO AVOID

```
❌ MongoDB: Forgetting $ in operators
   Wrong:  { age: { gt: 25 } }
   Right:  { age: { $gt: 25 } }

❌ MongoDB: Not awaiting async calls
   Wrong:  const result = collection.findOne(...);
   Right:  const result = await collection.findOne(...);

❌ ArangoDB: Forgetting RETURN statement
   Wrong:  FOR user IN users FILTER user.age > 25
   Right:  FOR user IN users FILTER user.age > 25 RETURN user

❌ ArangoDB: Wrong edge direction
   Wrong:  FOR v OUTBOUND "users/alice" FOLLOW "users"
   Right:  FOR v OUTBOUND "users/alice" GRAPH "graphName"

❌ Both: Treating distributed DB like single server
   → Remember eventual consistency
   → Remember replication lag
   → Remember partition tolerance

❌ Both: Not using indexes
   → 1M documents = very slow without index
   → Always index frequently filtered fields
```

---

## PERFORMANCE TIPS

```
✓ MongoDB:
  - Créer index sur champs WHERE/FILTER
  - Utiliser aggregation pipeline (côté serveur)
  - Limiter les résultats avec $limit
  - Pagination avec $skip/$limit

✓ ArangoDB:
  - Index sur champs FILTER
  - Éviter traversées trop profondes (99 levels = lent)
  - COLLECT au lieu de $group quand possible
  - LET pour pré-calculer

✓ Général:
  - Dénormaliser les données frequemment lues
  - Partition/Shard par clé logique
  - Monitoring de la replication lag
  - Backups réguliers
```

---

## EXAM ROOM COMMANDS

### **MongoDB (si mongosh disponible)**

```javascript
// Lister bases
show dbs

// Utiliser base
use myDb

// Lister collections
show collections

// Voir un document
db.users.findOne()

// Compter documents
db.users.countDocuments()

// Aggregation simple
db.orders.aggregate([
  { $match: { size: "medium" } },
  { $group: { _id: "$name", total: { $sum: "$quantity" } } }
])
```

### **ArangoDB (si arangosh ou WebUI)**

```javascript
// Lister bases
db._databases()

// Lister collections
db._collections()

// Query simple
db._query(`FOR user IN users RETURN user`).toArray()

// WITH COUNT (count rows)
db._query(`FOR user IN users COLLECT WITH COUNT INTO count RETURN count`).toArray()
```

---

## MEMORY JOGGERS

```
"ACID is strict, BASE is fast"

"CAP: Choose 2 of 3"

"Mongo = Documents, Arango = Documents + Graphs"

"Replication = Copies, Clustering = Partitions"

"$match/$group/$ sort = WHERE/GROUP BY/ORDER BY"

"OUTBOUND = follow edges, INBOUND = reverse"

"Aggregation = Pipeline = stages"

"No schema = Flexibility, Strict schema = Safety"
```

---

Fin de la référence rapide !

Gardez ce document à proximité pendant révisions ! 📝
