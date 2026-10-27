// Les huit vélos du parc et les sept réparations de l'atelier. Ne modifiez pas ce fichier.
public static class Donnees
{
    public static List<Velo> ChargerVelos()
    {
        return new List<Velo>
        {
            new("Colibri", "ville", 2023, 12, 64),
            new("Bison", "cargo", 2021, 28, 45),
            new("Chamois", "VTT", 2022, 22, 38),
            new("Merle", "ville", 2020, 10, 51),
            new("Mulet", "cargo", 2024, 30, 52),
            new("Lynx", "VTT", 2024, 25, 17),
            new("Hirondelle", "ville", 2022, 14, 72),
            new("Yack", "cargo", 2023, 26, 33),
        };
    }

    // Les sept réparations faites à l'atelier.
    public static List<Reparation> ChargerReparations()
    {
        return new List<Reparation>
        {
            new("Mulet", "freins", 80),
            new("Colibri", "chaîne", 35),
            new("Mulet", "pneu", 60),
            new("Merle", "freins", 45),
            new("Castor", "pneu", 50),
            new("Lynx", "selle", 70),
            new("Yack", "chaîne", 40),
        };
    }
}
