const users = db.collection("users");

await users.save({
    _key: "alice",
    name: "Alice Smith",
    email: "alice@example.com",
    age: 28
});