using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

var client = new MongoClient("mongodb://localhost:27017");
var db = client.GetDatabase("pizzaDb");
var collection = db.GetCollection<BsonDocument>("orders");