const users = db.collection("users");
await users.remove("alice");

const follows = db.collection("follows");
await follows.remove("edge_id");