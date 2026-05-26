using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var db = client.GetDatabase("pizzaDb");
        var orders = db.GetCollection<BsonDocument>("orders");

        // INSERT
        await orders.InsertManyAsync(new[]
        {
            new BsonDocument { { "_id", 0 }, { "name", "Pepperoni" }, { "size", "small" }, { "price", 19 }, { "quantity", 10 }, { "date", new BsonDateTime(new DateTime(2021, 3, 13, 8, 14, 30)) } },
            new BsonDocument { { "_id", 1 }, { "name", "Pepperoni" }, { "size", "medium" }, { "price", 20 }, { "quantity", 20 }, { "date", new BsonDateTime(new DateTime(2021, 3, 13, 9, 13, 24)) } },
            new BsonDocument { { "_id", 2 }, { "name", "Cheese" }, { "size", "large" }, { "price", 14 }, { "quantity", 10 }, { "date", new BsonDateTime(new DateTime(2021, 3, 17, 9, 22, 12)) } }
        });

        // AGGREGATION: Group medium sizes
        var pipeline = new BsonDocument[]
        {
            new BsonDocument("$match", new BsonDocument("size", "medium")),
            new BsonDocument("$group", new BsonDocument { { "_id", "$name" }, { "total", new BsonDocument("$sum", "$quantity") } })
        };

        var cursor = await orders.AggregateAsync<BsonDocument>(pipeline);
        var results = await cursor.ToListAsync();

        foreach (var r in results)
            Console.WriteLine($"{r["_id"]}: {r["total"]} pizzas");
    }
}