var filter = Builders<BsonDocument>.Filter.Eq("name", "Pepperoni");
var update = Builders<BsonDocument>.Update
    .Set("price", 22)
    .Inc("quantity", 5);
    
await collection.UpdateOneAsync(filter, update);
await collection.UpdateManyAsync(filter, update);