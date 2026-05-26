// Une pizza
await collection.InsertOneAsync(new BsonDocument
{
    { "name", "Pepperoni" },
    { "size", "medium" },
    { "price", 20 },
    { "quantity", 20 }
});

// Plusieurs
var docs = new List<BsonDocument>
{
    new BsonDocument { { "name", "Cheese" }, { "size", "large" } },
    new BsonDocument { { "name", "Vegan" }, { "size", "small" } }
};
await collection.InsertManyAsync(docs);