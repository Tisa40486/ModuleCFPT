FOR x IN collection           // FROM
FILTER x.age > 25             // WHERE
COLLECT x.city WITH COUNT     // GROUP BY
RETURN                        // SELECT
SORT BY x.age DESC            // ORDER BY
LIMIT 10                      // LIMIT
LENGTH(array)                 // COUNT
CONCAT(a, b)                  // String concat
DATE_NOW()                    // Current date