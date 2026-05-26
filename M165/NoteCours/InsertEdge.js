const follows = db.collection("follows");

await follows.save({
    _from: "users/alice",
    _to: "users/bob",
    followedAt: "2024-01-15"
});