# 💻 EXEMPLES DE CODE COMPLETS & PRÊTS À TESTER

---

## MONGODB - EXEMPLE COMPLET EN C#

### **Projet: Gestion de Pizzas (du cours)**

```csharp
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class PizzaService
{
    private readonly IMongoCollection<BsonDocument> ordersCollection;

    public PizzaService(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        ordersCollection = database.GetCollection<BsonDocument>("orders");
    }

    // ==================== CREATE ====================
    public async Task InsertOrders()
    {
        var orders = new List<BsonDocument>
        {
            new BsonDocument
            {
                { "_id", 0 },
                { "name", "Pepperoni" },
                { "size", "small" },
                { "price", 19 },
                { "quantity", 10 },
                { "date", new BsonDateTime(new DateTime(2021, 3, 13, 8, 14, 30)) }
            },
            new BsonDocument
            {
                { "_id", 1 },
                { "name", "Pepperoni" },
                { "size", "medium" },
                { "price", 20 },
                { "quantity", 20 },
                { "date", new BsonDateTime(new DateTime(2021, 3, 13, 9, 13, 24)) }
            },
            new BsonDocument
            {
                { "_id", 2 },
                { "name", "Pepperoni" },
                { "size", "large" },
                { "price", 21 },
                { "quantity", 30 },
                { "date", new BsonDateTime(new DateTime(2021, 3, 17, 9, 22, 12)) }
            },
            new BsonDocument
            {
                { "_id", 3 },
                { "name", "Cheese" },
                { "size", "small" },
                { "price", 12 },
                { "quantity", 15 },
                { "date", new BsonDateTime(new DateTime(2021, 3, 13, 11, 21, 39)) }
            },
            new BsonDocument
            {
                { "_id", 4 },
                { "name", "Cheese" },
                { "size", "medium" },
                { "price", 13 },
                { "quantity", 50 },
                { "date", new BsonDateTime(new DateTime(2022, 1, 12, 21, 23, 13)) }
            },
            new BsonDocument
            {
                { "_id", 5 },
                { "name", "Cheese" },
                { "size", "large" },
                { "price", 14 },
                { "quantity", 10 },
                { "date", new BsonDateTime(new DateTime(2022, 1, 12, 5, 8, 13)) }
            },
            new BsonDocument
            {
                { "_id", 6 },
                { "name", "Vegan" },
                { "size", "small" },
                { "price", 17 },
                { "quantity", 10 },
                { "date", new BsonDateTime(new DateTime(2021, 1, 13, 5, 8, 13)) }
            },
            new BsonDocument
            {
                { "_id", 7 },
                { "name", "Vegan" },
                { "size", "medium" },
                { "price", 18 },
                { "quantity", 10 },
                { "date", new BsonDateTime(new DateTime(2021, 1, 13, 5, 10, 13)) }
            }
        };

        await ordersCollection.InsertManyAsync(orders);
        Console.WriteLine("✓ 8 commandes de pizza insérées!");
    }

    // ==================== READ ====================
    public async Task FindAllOrders()
    {
        Console.WriteLine("\n=== TOUTES LES COMMANDES ===");
        var allOrders = await ordersCollection.Find(_ => true).ToListAsync();

        foreach (var order in allOrders)
        {
            Console.WriteLine($"ID: {order["_id"]}, " +
                            $"Pizza: {order["name"]}, " +
                            $"Taille: {order["size"]}, " +
                            $"Prix: {order["price"]}€, " +
                            $"Quantité: {order["quantity"]}");
        }
    }

    // ==================== AGGREGATION EXEMPLE 1 ====================
    // Requête: Grouper par nom et calculer quantité totale
    // pour les tailles "medium" uniquement
    public async Task AggregationExample1()
    {
        Console.WriteLine("\n=== AGGREGATION 1: Pizzas Medium (Quantité Totale) ===");

        var pipeline = new BsonDocument[]
        {
            // Stage 1: Filtrer (garder seulement medium)
            new BsonDocument("$match", 
                new BsonDocument("size", "medium")
            ),
            
            // Stage 2: Grouper par nom et sommer quantités
            new BsonDocument("$group",
                new BsonDocument
                {
                    { "_id", "$name" },
                    { "totalQuantity", new BsonDocument("$sum", "$quantity") }
                }
            )
        };

        var cursor = await ordersCollection.AggregateAsync<BsonDocument>(pipeline);
        var results = await cursor.ToListAsync();

        Console.WriteLine("\nRésultats:");
        foreach (var result in results)
        {
            Console.WriteLine($"Pizza: {result["_id"]}, " +
                            $"Quantité Total: {result["totalQuantity"]}");
        }

        Console.WriteLine("\nExplication:");
        Console.WriteLine("Stage 1 ($match): Garder seulement size='medium'");
        Console.WriteLine("  → Pepperoni(qty:20), Cheese(qty:50), Vegan(qty:10)");
        Console.WriteLine("Stage 2 ($group): Grouper par pizza et sommer quantités");
        Console.WriteLine("  → Pepperoni: 20, Cheese: 50, Vegan: 10");
    }

    // ==================== AGGREGATION EXEMPLE 2 ====================
    // Requête: Filtre par dates, groupe par jour, calcule valeur totale et moyenne
    public async Task AggregationExample2()
    {
        Console.WriteLine("\n=== AGGREGATION 2: Analyse par Date (Valeur Totale & Moyenne) ===");

        DateTime startDate = new DateTime(2021, 1, 13);
        DateTime endDate = new DateTime(2021, 3, 14);

        var dateFilter = new BsonDocument
        {
            { "$gte", startDate },
            { "$lt", endDate }
        };

        var pipeline = new BsonDocument[]
        {
            // Stage 1: Filtrer par dates
            new BsonDocument("$match",
                new BsonDocument("date", dateFilter)
            ),
            
            // Stage 2: Grouper par jour et calculer
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
            
            // Stage 3: Trier par valeur décroissante
            new BsonDocument("$sort",
                new BsonDocument("totalOrderValue", -1)
            )
        };

        var cursor = await ordersCollection.AggregateAsync<BsonDocument>(pipeline);
        var results = await cursor.ToListAsync();

        Console.WriteLine("\nRésultats:");
        foreach (var result in results)
        {
            Console.WriteLine($"Date: {result["_id"]}, " +
                            $"Valeur Totale: {result["totalOrderValue"]}€, " +
                            $"Quantité Moyenne: {result["averageOrderQuantity"]}");
        }

        Console.WriteLine("\nExplication:");
        Console.WriteLine("Stage 1 ($match): Garder commandes entre 2021-01-13 et 2021-03-14");
        Console.WriteLine("Stage 2 ($group): Grouper par jour et calculer");
        Console.WriteLine("  - totalOrderValue = SUM(price * quantity)");
        Console.WriteLine("  - averageOrderQuantity = AVG(quantity)");
        Console.WriteLine("Stage 3 ($sort): Trier par valeur décroissante");
    }

    // ==================== UPDATE ====================
    public async Task UpdateOrder()
    {
        Console.WriteLine("\n=== UPDATE: Mettre à jour une commande ===");

        var filter = Builders<BsonDocument>.Filter.Eq("_id", 1);
        var update = Builders<BsonDocument>.Update
            .Set("price", 22)
            .Set("quantity", 25);

        var result = await ordersCollection.UpdateOneAsync(filter, update);

        Console.WriteLine($"Documents modifiés: {result.ModifiedCount}");
        Console.WriteLine("✓ Pepperoni medium (ID:1) mise à jour!");
    }

    // ==================== DELETE ====================
    public async Task DeleteOrder()
    {
        Console.WriteLine("\n=== DELETE: Supprimer une commande ===");

        var filter = Builders<BsonDocument>.Filter.Eq("_id", 7);
        var result = await ordersCollection.DeleteOneAsync(filter);

        Console.WriteLine($"Documents supprimés: {result.DeletedCount}");
        Console.WriteLine("✓ Vegan medium (ID:7) supprimée!");
    }
}

// ==================== PROGRAMME PRINCIPAL ====================
class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "pizzaDb";

        var service = new PizzaService(connectionString, databaseName);

        Console.WriteLine("========== MONGODB PIZZA MANAGEMENT ==========\n");

        try
        {
            // INSERT
            await service.InsertOrders();

            // READ
            await service.FindAllOrders();

            // AGGREGATION 1
            await service.AggregationExample1();

            // AGGREGATION 2
            await service.AggregationExample2();

            // UPDATE
            await service.UpdateOrder();

            // DELETE
            await service.DeleteOrder();

            Console.WriteLine("\n✓ Tous les exemples ont réussi!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Erreur: {ex.Message}");
        }
    }
}
```

---

## ARANGODB - EXEMPLE COMPLET EN JAVASCRIPT/NODE.JS

### **Projet: Réseau Social**

```javascript
const arangojs = require("arangojs");
const { Database } = arangojs;

class SocialNetwork {
    constructor(url = "http://localhost:8529") {
        this.db = new Database({ url });
        this.db.useBasicAuth("root", "password");
    }

    // ==================== SETUP ====================
    async setup() {
        try {
            // Créer la base de données
            await this.db.createDatabase("social_app");
            this.db.useDatabase("social_app");
            console.log("✓ Base de données créée!");

            // Créer les collections
            const users = await this.db.createCollection("users");
            console.log("✓ Collection 'users' créée!");

            const follows = await this.db.createEdgeCollection("follows");
            console.log("✓ Collection 'follows' créée!");

            const likes = await this.db.createEdgeCollection("likes");
            console.log("✓ Collection 'likes' créée!");

        } catch (error) {
            if (error.code === 409) {
                // Base de données existe déjà
                this.db.useDatabase("social_app");
            } else {
                console.error("Erreur lors de la création:", error);
            }
        }
    }

    // ==================== CREATE ====================
    async insertUsers() {
        console.log("\n=== INSERT: Ajouter utilisateurs ===");

        const users = this.db.collection("users");

        const userData = [
            {
                _key: "alice",
                name: "Alice Smith",
                email: "alice@example.com",
                age: 28,
                city: "Paris"
            },
            {
                _key: "bob",
                name: "Bob Johnson",
                email: "bob@example.com",
                age: 32,
                city: "London"
            },
            {
                _key: "charlie",
                name: "Charlie Brown",
                email: "charlie@example.com",
                age: 25,
                city: "Berlin"
            },
            {
                _key: "david",
                name: "David Lee",
                email: "david@example.com",
                age: 29,
                city: "Tokyo"
            }
        ];

        for (const user of userData) {
            try {
                await users.save(user);
            } catch (error) {
                if (error.code !== 409) throw error;
            }
        }

        console.log("✓ 4 utilisateurs ajoutés!");
    }

    async insertFollows() {
        console.log("\n=== INSERT: Ajouter relations (follows) ===");

        const follows = this.db.collection("follows");

        const followData = [
            {
                _from: "users/alice",
                _to: "users/bob",
                followedAt: "2024-01-15"
            },
            {
                _from: "users/alice",
                _to: "users/charlie",
                followedAt: "2024-01-20"
            },
            {
                _from: "users/bob",
                _to: "users/charlie",
                followedAt: "2024-02-10"
            },
            {
                _from: "users/bob",
                _to: "users/david",
                followedAt: "2024-02-05"
            },
            {
                _from: "users/charlie",
                _to: "users/david",
                followedAt: "2024-02-12"
            }
        ];

        for (const follow of followData) {
            try {
                await follows.save(follow);
            } catch (error) {
                if (error.code !== 409) throw error;
            }
        }

        console.log("✓ Relations créées: Alice→Bob, Alice→Charlie, " +
                    "Bob→Charlie, Bob→David, Charlie→David");
    }

    // ==================== READ ====================
    async readAllUsers() {
        console.log("\n=== READ: Tous les utilisateurs ===");

        const cursor = await this.db.query(`
            FOR user IN users
                RETURN {
                    key: user._key,
                    name: user.name,
                    email: user.email,
                    age: user.age,
                    city: user.city
                }
        `);

        const users = await cursor.all();

        console.log("\nUtilisateurs:");
        users.forEach(user => {
            console.log(`  - ${user.name} (${user.key}), ${user.age} ans, ${user.city}`);
        });
    }

    // ==================== GRAPH QUERY 1: Followers ====================
    async findFollowers(username) {
        console.log(`\n=== GRAPH: Qui suit ${username} ? ===`);

        const cursor = await this.db.query(`
            FOR edge IN follows
                FILTER edge._to == @userId
                FOR user IN users
                    FILTER user._id == edge._from
                    RETURN {
                        follower: user.name,
                        followedAt: edge.followedAt
                    }
        `, {
            userId: `users/${username}`
        });

        const followers = await cursor.all();

        console.log(`\nFollowers de ${username}:`);
        if (followers.length === 0) {
            console.log("  Aucun follower");
        } else {
            followers.forEach(f => {
                console.log(`  - ${f.follower} (suivi depuis ${f.followedAt})`);
            });
        }
    }

    // ==================== GRAPH QUERY 2: Qui Suit ====================
    async findFollowing(username) {
        console.log(`\n=== GRAPH: Qui suit ${username} ? ===`);

        const cursor = await this.db.query(`
            FOR edge IN follows
                FILTER edge._from == @userId
                FOR user IN users
                    FILTER user._id == edge._to
                    RETURN {
                        following: user.name,
                        followedAt: edge.followedAt
                    }
        `, {
            userId: `users/${username}`
        });

        const following = await cursor.all();

        console.log(`\n${username} suit:`);
        if (following.length === 0) {
            console.log("  Personne");
        } else {
            following.forEach(f => {
                console.log(`  - ${f.following} (suivi depuis ${f.followedAt})`);
            });
        }
    }

    // ==================== GRAPH QUERY 3: Amis d'Amis ====================
    async findFriendsOfFriends(username) {
        console.log(`\n=== GRAPH: Amis d'amis de ${username} ===`);

        const cursor = await this.db.query(`
            FOR friend IN 1..1
                OUTBOUND @userId
                GRAPH "social"
                FOR friendOfFriend IN 1..1
                    OUTBOUND friend._id
                    GRAPH "social"
                    FILTER friendOfFriend._id != @userId
                    FILTER friendOfFriend NOT IN (
                        FOR f IN 1..1 OUTBOUND @userId GRAPH "social" RETURN f._id
                    )
                    RETURN DISTINCT {
                        person: friendOfFriend.name,
                        through: friend.name
                    }
        `, {
            userId: `users/${username}`
        });

        const friendsOfFriends = await cursor.all();

        console.log(`\nAmis d'amis de ${username}:`);
        if (friendsOfFriends.length === 0) {
            console.log("  Aucun amis d'amis");
        } else {
            friendsOfFriends.forEach(f => {
                console.log(`  - ${f.person} (à travers ${f.through})`);
            });
        }
    }

    // ==================== GRAPH QUERY 4: Utilisateur le Plus Suivi ====================
    async findMostFollowed() {
        console.log("\n=== GRAPH: Utilisateur le plus suivi ===");

        const cursor = await this.db.query(`
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
        `);

        const results = await cursor.all();

        console.log("\nRanking:");
        results.forEach((result, index) => {
            console.log(`  ${index + 1}. ${result.user} - ${result.followerCount} followers`);
        });
    }

    // ==================== UPDATE ====================
    async updateUser(username, updatedData) {
        console.log(`\n=== UPDATE: Mettre à jour ${username} ===`);

        const users = this.db.collection("users");

        try {
            await users.update(username, updatedData);
            console.log(`✓ ${username} mise à jour avec:`, updatedData);
        } catch (error) {
            console.error("Erreur lors de la mise à jour:", error);
        }
    }

    // ==================== DELETE ====================
    async deleteUser(username) {
        console.log(`\n=== DELETE: Supprimer ${username} ===`);

        const users = this.db.collection("users");

        try {
            await users.remove(username);
            console.log(`✓ ${username} supprimé!`);
        } catch (error) {
            console.error("Erreur lors de la suppression:", error);
        }
    }

    // ==================== CREATION GRAPH POUR TRAVERSÉE ====================
    async createGraph() {
        try {
            const graph = this.db.graph("social");
            
            await graph.create({
                edgeDefinitions: [
                    {
                        collection: "follows",
                        from: ["users"],
                        to: ["users"]
                    }
                ]
            });

            console.log("✓ Graph 'social' créé!");
        } catch (error) {
            if (error.code !== 409) {
                console.error("Erreur lors de la création du graph:", error);
            }
        }
    }
}

// ==================== PROGRAMME PRINCIPAL ====================
async function main() {
    const network = new SocialNetwork("http://localhost:8529");

    console.log("========== ARANGODB SOCIAL NETWORK ==========\n");

    try {
        // Setup
        await network.setup();
        await network.createGraph();

        // Insert Data
        await network.insertUsers();
        await network.insertFollows();

        // Read
        await network.readAllUsers();

        // Graph Queries
        await network.findFollowers("alice");
        await network.findFollowing("alice");
        await network.findFriendsOfFriends("alice");
        await network.findMostFollowed();

        // Update
        await network.updateUser("alice", { age: 29, city: "Lyon" });

        console.log("\n✓ Tous les exemples ont réussi!");

    } catch (error) {
        console.error("✗ Erreur:", error);
    }
}

main();
```

---

## CHEAT SHEET POUR L'EXAM

### **MongoDB - Opérateurs Essentiels**

```javascript
// COMPARISON
$eq, $ne, $gt, $gte, $lt, $lte, $in, $nin

// LOGICAL
$and, $or, $not, $nor

// UPDATE
$set, $inc, $push, $pull, $pop, $unset, $currentDate

// AGGREGATION STAGES
$match, $group, $sort, $limit, $skip, $project, $lookup, $unwind

// AGGREGATION OPERATORS
$sum, $avg, $min, $max, $push, $addToSet, $first, $last, $count
```

### **ArangoDB - AQL Essentials**

```javascript
// TRAVERSÉE BASIQUE
FOR vertex IN collection
  RETURN vertex

// AVEC FILTRE
FOR vertex IN collection
  FILTER vertex.age > 25
  RETURN vertex

// GRAPH TRAVERSAL
FOR vertex, edge, path IN depth
  OUTBOUND startVertex
  GRAPH graphName
  RETURN vertex

// INBOUND (inverse)
FOR vertex IN 1..1
  INBOUND "users/alice"
  GRAPH "social"
  RETURN vertex.name
```

---

Fin des exemples de code!

Prêt à réussir l'exam ! 🚀
