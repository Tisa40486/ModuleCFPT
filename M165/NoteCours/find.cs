// Tous
var all = await collection.Find(new BsonDocument()).ToListAsync();
foreach (var doc in all)
    Console.WriteLine(doc["name"]);

// WHERE condition
var filter = Builders<BsonDocument>.Filter.Gt("price", 15);
var result = await collection.Find(filter).ToListAsync();

// AND condition
var filter = Builders<BsonDocument>.Filter.And(
    Builders<BsonDocument>.Filter.Gt("price", 15),
    Builders<BsonDocument>.Filter.Eq("size", "medium")
);
var result = await collection.Find(filter).ToListAsync();

// Operators
$eq, $ne, $gt, $gte, $lt, $lte, $in, $nin

// $eq    = Equal (égal à)
//          { age: { $eq: 30 } }  → age = 30

// $ne    = Not Equal (pas égal à)
//          { age: { $ne: 30 } }  → age ≠ 30

// $gt    = Greater Than (plus grand que)
//          { age: { $gt: 25 } }  → age > 25

// $gte   = Greater or Equal (plus grand ou égal)
//          { age: { $gte: 25 } } → age ≥ 25

// $lt    = Less Than (plus petit que)
//          { age: { $lt: 35 } }  → age < 35

// $lte   = Less or Equal (plus petit ou égal)
//          { age: { $lte: 35 } } → age ≤ 35

// $in    = IN (dans la liste)
//          { city: { $in: ["Paris", "London"] } } → city IN ("Paris", "London")

// $nin   = Not IN (pas dans la liste)
//          { city: { $nin: ["Paris"] } } → city NOT IN ("Paris")