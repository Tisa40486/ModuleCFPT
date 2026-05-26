const cursor = await db.query(`
    FOR edge IN follows
        FILTER edge._to == @userId
        FOR user IN users
            FILTER user._id == edge._from
            RETURN {
                follower: user.name,
                followedAt: edge.followedAt
            }
`, { userId: "users/alice" });

const followers = await cursor.all();