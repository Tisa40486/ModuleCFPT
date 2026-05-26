const arangojs = require("arangojs");
const { Database } = arangojs;

const db = new Database({ url: "http://localhost:8529" });
db.useBasicAuth("root", "password");
db.useDatabase("social_app");