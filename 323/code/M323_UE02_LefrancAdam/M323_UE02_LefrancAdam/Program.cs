// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information

namespace test
{
    public record Voiture(string Marque, string Modele, int Prix, string Carburant, int Kilometrage,int Annee);

    public class App()
    {
        static void Main(string[] args)
        {
            Func<double, double> remise = RetirerRemiseFixe;
            Func<double, double> tva = AjouterTva;

            double prix = 18000;
            double remisePuisTva = tva(remise(prix));
            double tvaPuisRemise = remise(tva(prix));

            Console.WriteLine($"{remisePuisTva:F2} CHF");
            Console.WriteLine($"{tvaPuisRemise:F2} CHF");
            
            List<Voiture> catalogue = Donnée.ChargerCatalogue();
            Console.WriteLine(EtiquetteDe(catalogue[0]));
        }
        static double RetirerRemiseFixe(double price)
        {
            price -= 1000;
            return price;
        }

        static double AjouterTva(double price)
        {
            price *= 1.081;
            return price;
        }
        static string EtiquetteDe(Voiture v)
        {
            return $"{v.Marque} {v.Modele} ({v.Annee})";
        }
        
    }

}
