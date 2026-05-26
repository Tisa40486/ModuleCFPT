var filter = Builders<BsonDocument>.Filter.Eq("name", "Pepperoni");
await collection.DeleteOneAsync(filter);
await collection.DeleteManyAsync(filter);