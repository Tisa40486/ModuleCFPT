// Grouper et Sommer

var pipeline = new BsonDocument[]
{
    // Filtre: size = "medium"
    new BsonDocument("$match", new BsonDocument("size", "medium")),
    
    // Groupe par name et somme les quantities
    new BsonDocument("$group", new BsonDocument
    {
        { "_id", "$name" },
        { "totalQty", new BsonDocument("$sum", "$quantity") }
    })
};

var cursor = await collection.AggregateAsync<BsonDocument>(pipeline);
var results = await cursor.ToListAsync();

foreach (var r in results)
    Console.WriteLine($"{r["_id"]}: {r["totalQty"]}");

