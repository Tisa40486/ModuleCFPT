// Dates, Calculs, Sort

var startDate = new DateTime(2021, 1, 13);
var endDate = new DateTime(2021, 3, 14);

var pipeline = new BsonDocument[]
{
    // Filtre dates
    new BsonDocument("$match", new BsonDocument("date",
        new BsonDocument
        {
            { "$gte", startDate },
            { "$lt", endDate }
        }
    )),
    
    // Groupe par jour
    new BsonDocument("$group", new BsonDocument
    {
        {
            "_id",
            new BsonDocument("$dateToString", new BsonDocument
            {
                { "format", "%Y-%m-%d" },
                { "date", "$date" }
            })
        },
        {
            "totalValue",
            new BsonDocument("$sum",
                new BsonDocument("$multiply",
                    new BsonArray { "$price", "$quantity" }
                )
            )
        },
        { "avgQty", new BsonDocument("$avg", "$quantity") }
    }),
    
    // Sort descending
    new BsonDocument("$sort", new BsonDocument("totalValue", -1))
};

var cursor = await collection.AggregateAsync<BsonDocument>(pipeline);
var results = await cursor.ToListAsync();

foreach (var r in results)
    Console.WriteLine($"{r["_id"]}: {r["totalValue"]}€, Avg: {r["avgQty"]}");