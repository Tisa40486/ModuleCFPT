const cursor = await db.query(
    `FOR user IN users
     FILTER user.age > @minAge
     FILTER user.city == @city
     RETURN user`,
    { minAge: 25, city: "Paris" }
);
const results = await cursor.all();