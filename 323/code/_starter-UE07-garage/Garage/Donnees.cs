// Jeu de donnees du fil rouge. Ne pas modifier.
// Catalogue : total 303 400 CHF, 730 000 km,
// 4 essence, 3 diesel, 3 electrique, 2 hybride.
// Revisions : 10 interventions, 4 965 CHF.
public static class Donnees
{
    public static List<Voiture> ChargerCatalogue()
    {
        return new List<Voiture>
        {
            new("Renault", "Zoe", 22000, "électrique", 15000, 2021),
            new("VW", "Golf", 18000, "diesel", 120000, 2016),
            new("Tesla", "Model 3", 41000, "électrique", 30000, 2022),
            new("Peugeot", "208", 14500, "essence", 68000, 2018),
            new("Toyota", "Yaris", 19500, "hybride", 42000, 2020),
            new("BMW", "Serie 1", 27000, "diesel", 95000, 2017),
            new("Fiat", "Panda", 8900, "essence", 130000, 2012),
            new("Skoda", "Octavia", 23500, "diesel", 88000, 2019),
            new("Hyundai", "Kona", 31000, "électrique", 12000, 2023),
            new("Audi", "A3", 34000, "essence", 45000, 2021),
            new("Dacia", "Sandero", 12000, "essence", 76000, 2019),
            new("Volvo", "XC40", 52000, "hybride", 9000, 2024),
        };
    }

    public static List<Revision> ChargerRevisions()
    {
        return new List<Revision>
        {
            new("Zoe", "vidange", 180, 2),
            new("Golf", "freins", 640, 3),
            new("Golf", "vidange", 190, 7),
            new("Model 3", "pneus", 890, 1),
            new("208", "vidange", 170, 4),
            new("Panda", "embrayage", 1250, 5),
            new("Panda", "freins", 520, 9),
            new("Octavia", "vidange", 200, 6),
            new("Kona", "pneus", 760, 8),
            new("Sandero", "vidange", 165, 3),
        };
    }
}
