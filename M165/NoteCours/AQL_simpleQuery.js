// Tous
const cursor = await db.query(`FOR user IN users RETURN user`);
const all = await cursor.all();

// WHERE condition
const cursor = await db.query(`
    FOR user IN users
    FILTER user.age > 25
    RETURN user
`);
const results = await cursor.all();

// SELECT specific fields
const cursor = await db.query(`
    FOR user IN users
    RETURN { name: user.name, age: user.age }
`);
const results = await cursor.all();

// ORDER BY
const cursor = await db.query(`
    FOR user IN users
    RETURN user
    ORDER BY user.age DESC
`);
const results = await cursor.all();

// LIMIT
const cursor = await db.query(`
    FOR user IN users
    LIMIT 5
    RETURN user
`);
const results = await cursor.all();