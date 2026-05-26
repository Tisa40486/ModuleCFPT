const users = db.collection("users");

await users.update("alice", {
    age: 29,
    city: "Lyon"
});