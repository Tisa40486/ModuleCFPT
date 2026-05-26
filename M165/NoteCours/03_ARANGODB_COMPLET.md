# 🔴 ARANGODB - GUIDE COMPLET

---

## C'EST QUOI ARANGODB ?

### **Explication Enfant**

Imagine une **bibliothèque**:

**MongoDB** = Chaque livre est rangé dans une armoire indépendante. Pas de relation entre eux.

**ArangoDB** = Les livres sont reliés entre eux:
- "Harry Potter 1" → pointeur vers "Harry Potter 2"
- "Cours de Maths" → pointeur vers "Exercices de Maths"
- Auteur "J.K. Rowling" → pointe vers tous ses livres

C'est une **base graphe** + **base documentaire**.

### **Définition Technique**

```
ArangoDB = Multi-Model Database

Supporte 3 modèles:

1. DOCUMENT MODEL (comme MongoDB)
   Collections de documents JSON
   
2. GRAPH MODEL (ce que MongoDB n'a pas)
   Documents + relations entre documents
   Parfait pour réseaux sociaux, recommandations
   
3. KEY-VALUE MODEL
   Simples paires clé-valeur
```

### **Pourquoi ArangoDB et pas MongoDB ?**

| Besoin | MongoDB | ArangoDB |
|--------|---------|----------|
| Documents JSON | ✓ | ✓ |
| Relations entre données | ✗ (pas natif) | ✓✓ (natif) |
| Requêtes de graphe | ✗ | ✓ |
| Recommandations | ✗ | ✓ |
| Réseaux sociaux | ✗ | ✓ |
| Taxonomies | ✗ | ✓ |
| Arborescences | ✗ | ✓ |
| Requêtes simples | ✓ | ✓ |
| Performance graphe | ✗ | ✓ (optimisée) |

---

## 🔗 MODÈLE GRAPHE D'ARANGODB

### **Vocabulaire de Base**

```
Vertex (Sommet) = Un document
Edge (Arête) = Une relation entre 2 documents

Exemple: Réseau social

Vertices (utilisateurs):
- Alice (document)
- Bob (document)
- Charlie (document)

Edges (relations):
- Alice --[follows]--> Bob
- Bob --[follows]--> Charlie
- Alice --[likes]--> Charlie
```

### **Exemple Complet: Réseau Social**

```javascript
// === COLLECTIONS DE VERTICES (Documents) ===

// Collection "users" (les utilisateurs)
{
  _key: "alice",
  name: "Alice Smith",
  email: "alice@example.com",
  age: 28,
  city: "Paris"
}

{
  _key: "bob",
  name: "Bob Johnson",
  email: "bob@example.com",
  age: 32,
  city: "London"
}

{
  _key: "charlie",
  name: "Charlie Brown",
  email: "charlie@example.com",
  age: 25,
  city: "Berlin"
}


// === COLLECTIONS D'EDGES (Relations) ===

// Collection "follows" (qui suit qui)
{
  _from: "users/alice",    // Source: Alice
  _to: "users/bob",        // Destination: Bob
  followedAt: "2024-01-15"
}

{
  _from: "users/bob",
  _to: "users/charlie",
  followedAt: "2024-02-10"
}

{
  _from: "users/alice",
  _to: "users/charlie",
  followedAt: "2024-01-20"
}

// Collection "likes" (qui aime quoi)
{
  _from: "users/alice",
  _to: "users/bob",     // Alice aime le profil de Bob
  type: "profile"
}

{
  _from: "users/bob",
  _to: "users/alice",
  type: "profile"
}
```

### **Visualisation du Graphe**

```
        Alice ────follows────> Bob
          ↓                      ↓
        likes                 follows
          ↓                      ↓
        ┌─────────────────────→ Charlie

Alice suit Bob
Alice suit Charlie
Bob suit Charlie

Alice aime Bob
Bob aime Alice
```

---

## 📦 COLLECTIONS ET DOCUMENTS

### **Types de Collections**

```javascript
// 1. VERTEX COLLECTION
// Contient des documents (vertices)
db.users      // Utilisateurs
db.products   // Produits
db.articles   // Articles

// 2. EDGE COLLECTION
// Contient des relations (edges)
db.follows    // "qui suit qui"
db.likes      // "qui aime quoi"
db.buys       // "qui achète quoi"
db.authors    // "qui a écrit quoi"
```

### **Structure d'un Document dans ArangoDB**

```javascript
// Document normal (sans relation)
{
  _key: "alice",           // Clé unique dans la collection
  _id: "users/alice",      // ID global (collection/clé)
  _rev: "1",               // Révision (pour contrôle concurrence)
  name: "Alice",
  email: "alice@example.com"
}

// Edge (relation avec _from et _to)
{
  _key: "follows1",
  _id: "follows/follows1",
  _from: "users/alice",    // Document source
  _to: "users/bob",        // Document destination
  followedAt: "2024-01-15"
}
```

### **Créer des Collections**

```javascript
// Créer une collection de vertices
db._create("users", { type: 2 })  // type: 2 = vertex

// Créer une collection d'edges
db._createEdgeCollection("follows")  // Automatiquement edge

// Vérifier
db.users
db.follows
```

### **Ajouter des Documents**

```javascript
// Ajouter un vertex (document)
db.users.insert({
  _key: "alice",
  name: "Alice Smith",
  email: "alice@example.com",
  age: 28
})

// Ajouter un edge (relation)
db.follows.insert({
  _from: "users/alice",
  _to: "users/bob",
  followedAt: "2024-01-15"
})

// Vérifier
db.users.all()
db.follows.all()
```

---

## 🎯 OPÉRATIONS CRUD EN ARANGODB

### **C - CREATE**

```javascript
// === ARANGODB QUERY LANGUAGE (AQL) ===
// Syntaxe similaire à SQL mais pour graphes

// Insérer un vertex
INSERT {
  _key: "alice",
  name: "Alice Smith",
  email: "alice@example.com",
  age: 28
} INTO users

// Insérer une edge
INSERT {
  _from: "users/alice",
  _to: "users/bob",
  followedAt: "2024-01-15"
} INTO follows
```

### **R - READ**

#### **Requête Simple**

```javascript
// Récupérer tous les utilisateurs
FOR user IN users
  RETURN user

// Résultat:
[
  { _key: "alice", _id: "users/alice", name: "Alice", ... },
  { _key: "bob", _id: "users/bob", name: "Bob", ... },
  { _key: "charlie", _id: "users/charlie", name: "Charlie", ... }
]
```

#### **Avec Filtres**

```javascript
// Utilisateurs de plus de 25 ans
FOR user IN users
  FILTER user.age > 25
  RETURN user

// Résultat:
[
  { _key: "alice", age: 28, ... },
  { _key: "bob", age: 32, ... }
]
```

#### **Projection (champs spécifiques)**

```javascript
// Retourner seulement name et email
FOR user IN users
  RETURN { name: user.name, email: user.email }

// Résultat:
[
  { name: "Alice Smith", email: "alice@example.com" },
  { name: "Bob Johnson", email: "bob@example.com" }
]
```

### **U - UPDATE**

```javascript
// Mettre à jour un utilisateur
UPDATE {
  _key: "alice"
} WITH {
  age: 29,
  city: "Lyon"
} IN users

// REPLACE (remplacer complètement)
REPLACE {
  _key: "alice"
} WITH {
  _key: "alice",
  name: "Alice Smith",
  email: "alice@example.com",
  age: 29
} IN users
```

### **D - DELETE**

```javascript
// Supprimer un utilisateur
REMOVE "alice" IN users

// Ou:
REMOVE {
  _key: "alice"
} IN users

// Supprimer une relation
REMOVE {
  _key: "follows1"
} IN follows
```

---

## 🔗 REQUÊTES DE GRAPHE (The Power!)

### **Traversée de Graphe: Qui suit Alice ?**

```javascript
// Qui suit Alice ?
// Requête: Trouver tous les edges où _to est Alice
// puis retourner les utilisateurs en _from

FOR edge IN follows
  FILTER edge._to == "users/alice"
  FOR user IN users
    FILTER user._id == edge._from
    RETURN {
      follower: user.name,
      followedAt: edge.followedAt
    }

// Résultat:
[
  { follower: "Bob Johnson", followedAt: "2024-02-01" },
  { follower: "Charlie Brown", followedAt: "2024-01-20" }
]
```

### **Traversée en Profondeur: Amis d'Amis**

```javascript
// Amis d'amis d'Alice (jusqu'à 2 degrés)
// Alice → Amis → Amis des Amis

FOR vertex, edge, path IN 2..2 
  OUTBOUND "users/alice" 
  GRAPH "social_network"
  
  RETURN {
    person: vertex.name,
    distance: path.edges.length
  }

// Résultat:
[
  { person: "Bob Johnson", distance: 1 },
  { person: "Charlie Brown", distance: 1 },
  { person: "David Lee", distance: 2 }
]
```

### **Chemins Récursifs: Tous les Amis**

```javascript
// Trouver TOUS les amis d'Alice (profondeur infinie)

FOR vertex, edge, path IN 1..99
  OUTBOUND "users/alice"
  FOLLOW follows
  
  RETURN DISTINCT vertex.name

// DISTINCT = pas de doublon
```

### **Requête Puissante: Recommandation**

```javascript
// Recommander des utilisateurs à Alice:
// "Personnes que ses amis suivent, mais qu'elle ne suit pas"

// Alice suit: Bob, Charlie
// Bob suit: David
// Charlie suit: David, Emma
// Résultat recommandé: David (que Bob et Charlie suivent)

FOR friend IN 1..1
  OUTBOUND "users/alice"
  FOLLOW follows
  
  FOR recommended IN 1..1
    OUTBOUND friend._id
    FOLLOW follows
    
    FILTER recommended._id != "users/alice" // Pas Alice elle-même
    FILTER recommended NOT IN (
      FOR f IN 1..1
        OUTBOUND "users/alice"
        FOLLOW follows
      RETURN f._id
    ) // Pas quelqu'un qu'elle suit déjà
    
    RETURN DISTINCT {
      recommended: recommended.name,
      recommendedBy: friend.name
    }
```

### **Analyseur de Réseau: Centralité**

```javascript
// Utilisateur le plus suivi

FOR user IN users
  LET followers = (
    FOR edge IN follows
      FILTER edge._to == user._id
      RETURN edge._from
  )
  
  RETURN {
    user: user.name,
    followerCount: LENGTH(followers)
  }
  
ORDER BY followerCount DESC
LIMIT 5

// Résultat (top 5):
[
  { user: "Charlie Brown", followerCount: 5 },
  { user: "Bob Johnson", followerCount: 4 },
  { user: "Alice Smith", followerCount: 2 }
]
```

---

## 💻 ARANGODB AVEC JAVASCRIPT/NODE.JS

### **Installation et Configuration**

```bash
# Installer le driver ArangoDB
npm install arangojs
```

```javascript
// Connexion de base
const arangojs = require("arangojs");
const { Database } = arangojs;

const db = new Database({
  url: "http://localhost:8529"
});

// Authentification (si nécessaire)
db.useBasicAuth("root", "password");

// Sélectionner base de données
db.useDatabase("myAppDb");
```

### **CREATE - Insérer**

```javascript
// Insérer un vertex
const users = db.collection("users");

await users.save({
  _key: "alice",
  name: "Alice Smith",
  email: "alice@example.com",
  age: 28
});

console.log("Alice ajoutée!");

// Insérer plusieurs
const documents = [
  { _key: "bob", name: "Bob Johnson", age: 32 },
  { _key: "charlie", name: "Charlie Brown", age: 25 }
];

await users.import(documents);
console.log("Plusieurs utilisateurs ajoutés!");
```

```javascript
// Insérer une edge (relation)
const follows = db.collection("follows");

await follows.save({
  _from: "users/alice",
  _to: "users/bob",
  followedAt: "2024-01-15"
});

console.log("Edge créée: Alice suit Bob");
```

### **READ - Lire**

```javascript
// Récupérer un document
const users = db.collection("users");

try {
  const alice = await users.document("alice");
  console.log("Alice:", alice);
  // Output: { _key: "alice", name: "Alice Smith", ... }
} catch (error) {
  console.log("Alice non trouvée");
}
```

```javascript
// Utiliser AQL pour requêtes
const cursor = await db.query(`
  FOR user IN users
    FILTER user.age > 25
    RETURN {
      name: user.name,
      age: user.age
    }
`);

const users = await cursor.all();
console.log(users);
// Output:
// [
//   { name: "Alice Smith", age: 28 },
//   { name: "Bob Johnson", age: 32 }
// ]
```

### **Requête AQL avec Paramètres**

```javascript
// Paramètres (évite SQL injection)
const cursor = await db.query(
  `
    FOR user IN users
      FILTER user.age > @minAge
      FILTER user.city == @city
      RETURN user
  `,
  {
    minAge: 25,
    city: "Paris"
  }
);

const results = await cursor.all();
console.log(results);
```

### **Traversée de Graphe avec JavaScript**

```javascript
// Qui suit Alice ?
const cursor = await db.query(`
  FOR edge IN follows
    FILTER edge._to == "users/alice"
    FOR user IN users
      FILTER user._id == edge._from
      RETURN {
        follower: user.name,
        followedAt: edge.followedAt
      }
`);

const followers = await cursor.all();
console.log("Followers d'Alice:", followers);
```

```javascript
// Amis d'amis
const cursor = await db.query(`
  FOR vertex, edge, path IN 2..2
    OUTBOUND "users/alice"
    GRAPH "social_network"
    RETURN {
      person: vertex.name,
      distance: path.edges.length
    }
`);

const friendsOfFriends = await cursor.all();
console.log("Amis d'amis:", friendsOfFriends);
```

### **UPDATE avec JavaScript**

```javascript
// Mettre à jour un document
const users = db.collection("users");

await users.update("alice", {
  age: 29,
  city: "Lyon"
});

console.log("Alice mise à jour!");
```

### **DELETE avec JavaScript**

```javascript
// Supprimer un document
const users = db.collection("users");

await users.remove("alice");
console.log("Alice supprimée!");

// Supprimer une edge
const follows = db.collection("follows");
await follows.remove("edge_id");
```

---

## 🌐 GRAPH THEORY EN ARANGODB

### **Cas d'Usage 1: Réseau Social**

```javascript
// Graphe:
// Users → follows → Users
// Users → likes → Posts
// Posts → hasComment → Comments

// Requête: "Recommandations de utilisateurs"
FOR user IN users
  FILTER user._id == "users/alice"
  
  // Ses amis
  FOR friend IN 1..1
    OUTBOUND user
    GRAPH "social"
    
    // Les amis de ses amis
    FOR friendOfFriend IN 1..1
      OUTBOUND friend
      GRAPH "social"
      
      FILTER friendOfFriend._id NOT IN (
        FOR f IN 1..1 OUTBOUND user GRAPH "social" RETURN f._id
      )
      
      RETURN {
        recommendation: friendOfFriend.name,
        mutualFriend: friend.name
      }
```

### **Cas d'Usage 2: Taxonomie de Produits**

```javascript
// Structure:
// Electronics
//   ├─ Smartphones
//   │   ├─ iPhone
//   │   └─ Android
//   └─ Laptops

// Collections:
// categories (vertex)
// categoryParent (edge: parent → enfant)

// Requête: "Tous les produits d'une catégorie et sous-catégories"
FOR category IN categories
  FILTER category._id == "categories/Smartphones"
  
  // Catégories enfants
  FOR subCategory IN 0..99
    INBOUND category
    GRAPH "product_taxonomy"
    
    RETURN DISTINCT subCategory.name
```

### **Cas d'Usage 3: Route la Plus Courte**

```javascript
// Graphe: Villes connectées par routes
// Cities (vertex)
// roads (edge: distance)

// Requête: "Route la plus courte de Paris à Berlin"
FOR path IN OUTBOUND "cities/paris" GRAPH "roads"
  FILTER path._id == "cities/berlin"
  
  RETURN {
    destination: path.name,
    routeLength: LENGTH(path)
  }
```

---

## 🔴 ARANGODB vs 🍃 MONGODB

### **Comparaison Directe**

| Aspect | MongoDB | ArangoDB |
|--------|---------|----------|
| Type | Document | Multi-Model (Doc + Graph + KV) |
| Modèle Graphe | ✗ (pas natif) | ✓ (natif) |
| Requêtes Graphe | ✗ (compliqué) | ✓ (AQL optimisé) |
| Performance Graphe | Lente (joins) | Rapide (traversée native) |
| Schéma | Flexible | Flexible |
| Langage Requête | MongoDB Query Language | AQL (type SQL) |
| Relations | Pas natif (denormalization) | Natif (edges) |
| Complexity Graphe | O(n) | O(nodes + edges) |
| Ecosystème | Très grand | Plus petit mais bon |

### **Quand Utiliser Quoi ?**

**Utilise MongoDB si:**
- Base de données simple (documents indépendants)
- Pas de relations complexes
- Besoin d'écosystème large
- Documents JSON purs
- Performance d'écriture critique

**Utilise ArangoDB si:**
- Relations entre documents (graphe)
- Recommandations
- Réseaux sociaux
- Taxonomies
- Traversées graphe récursives
- Multi-modèle utile
- Requêtes jointes complexes

---

## 📚 EXEMPLE COMPLET: BLOG AVEC COMMENTAIRES

### **Structure en MongoDB**

```javascript
// Collection posts
{
  _id: ObjectId("..."),
  title: "MongoDB vs ArangoDB",
  content: "...",
  author: ObjectId("..."),  // Référence, faut joindre
  createdAt: ISODate("...")
}

// Collection comments
{
  _id: ObjectId("..."),
  postId: ObjectId("..."),  // Référence, faut joindre
  text: "Great post!",
  author: ObjectId("..."),
  createdAt: ISODate("...")
}

// Requête: "Tous les commentaires d'un post avec auteurs"
// Faut 2-3 requêtes et joindre manuellement
const post = await posts.findOne({ _id: postId });
const comments = await comments.find({ postId });
// Puis boucler pour chaque auteur...
```

### **Structure en ArangoDB**

```javascript
// Collection posts (vertex)
{
  _key: "post1",
  title: "MongoDB vs ArangoDB",
  content: "...",
  createdAt: "2024-01-15"
}

// Collection users (vertex)
{
  _key: "alice",
  name: "Alice Smith",
  email: "alice@example.com"
}

// Collection authors (edge)
{
  _from: "users/alice",
  _to: "posts/post1",
  type: "wrote"
}

// Collection comments (vertex)
{
  _key: "comment1",
  text: "Great post!",
  createdAt: "2024-01-16"
}

// Collection commentsOn (edge)
{
  _from: "comments/comment1",
  _to: "posts/post1"
}

// Collection commentedBy (edge)
{
  _from: "users/alice",
  _to: "comments/comment1"
}

// REQUÊTE UNE SEULE (traversée graphe):
FOR comment IN 1..1
  INBOUND "posts/post1"
  GRAPH "blog"
  FOR author IN 1..1
    INBOUND comment
    GRAPH "blog"
    RETURN {
      text: comment.text,
      author: author.name,
      createdAt: comment.createdAt
    }

// Résultat:
// [
//   { text: "Great post!", author: "Alice Smith", createdAt: "2024-01-16" },
//   { text: "Thanks!", author: "Bob Johnson", createdAt: "2024-01-17" }
// ]
```

---

Fin Partie 3 - ArangoDB

Vous êtes maintenant prêt pour l'examen ! 🎓
