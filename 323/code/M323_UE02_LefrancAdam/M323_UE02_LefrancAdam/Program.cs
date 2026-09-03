namespace UE02
{
    public class App()
    {
        static bool MoinsDe100k(Voiture v) {return v.Kilometrage > 100000;}
        static bool EstElectrique(Voiture v){return v.Carburant == "électrique";}
        static bool EstDiesel(Voiture v) { return v.Carburant == "diesel";}
        static bool EstRecent(Voiture v){return v.Annee >= 2021;}
        static void Main(string[] args)
        {
            List<Voiture> catalogue = Donnée.ChargerCatalogue();
            Console.WriteLine("------- EST RECENT---------");
            Afficher(catalogue, EstRecent);
            Compter(catalogue, EstRecent);
            Console.WriteLine("------- EST DIESEL---------");
            Afficher(catalogue, EstDiesel);
            Compter(catalogue, EstDiesel);
            Console.WriteLine("------- EST ELEC---------");
            Afficher(catalogue, EstElectrique);
            Compter(catalogue, EstElectrique);
            Console.WriteLine("------- Moins de 100k---------");
            Compter(catalogue, MoinsDe100k);
        }
        static void Afficher(List<Voiture> catalogue, Predicate<Voiture> critere)
        {
            foreach (Voiture v in catalogue)
            {
                if (critere(v))
                {
                    Console.WriteLine(v.Modele);
                }
            }
        }

        static void Compter(List<Voiture> catalogue, Predicate<Voiture> critere)
        {
            var count = 0;
            foreach (Voiture voiture in catalogue)
            {
                if (critere(voiture))
                {
                    count++;
                }
                
            }
            Console.WriteLine($"{count} voitures trouvées !!");
        }
        
    }

}
