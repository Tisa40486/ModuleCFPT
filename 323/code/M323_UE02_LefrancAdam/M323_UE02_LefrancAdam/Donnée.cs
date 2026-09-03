namespace UE02;

public class Donnée
{
    public static List<Voiture> ChargerCatalogue()
    {
        return new List<Voiture>
        {
            new Voiture("Renault", "Zoe", 22000,
                "électrique", 15000, 2021),
            new Voiture("VW", "Golf", 18000,
                "diesel", 120000, 2016),
            new Voiture("Tesla", "Model 3", 41000,
                "électrique", 30000, 2022),
            new Voiture("Peugeot", "208", 14500,
                "essence", 68000, 2018),
            new Voiture("Toyota", "Yaris", 19500,
                "hybride", 42000, 2020),
            new Voiture("BMW", "Serie 1", 27000,
                "diesel", 95000, 2017),
            new Voiture("Fiat", "Panda", 8900,
                "essence", 130000, 2012),
            new Voiture("Skoda", "Octavia", 23500,
                "diesel", 88000, 2019),
            new Voiture("Hyundai", "Kona", 31000,
                "électrique", 12000, 2023),
            new Voiture("Audi", "A3", 34000,
                "essence", 45000, 2021),
            new Voiture("Dacia", "Sandero", 12000,
                "essence", 76000, 2019),
            new Voiture("Volvo", "XC40", 52000,
                "hybride", 9000, 2024),
        };
    }
}