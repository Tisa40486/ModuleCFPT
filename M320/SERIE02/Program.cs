namespace SERIE02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personne conducteur = new Personne("Sayan", 1.50, 99);
            Personne passager = new Personne("Mattis", 1.80, 50);
            Voiture voiture1 = new Voiture("Volvo", "Blue");

            Console.WriteLine(conducteur.ToString());

            Console.WriteLine(voiture1.ToString());


            Console.WriteLine(voiture1.Roule(conducteur));
            Console.WriteLine(voiture1.Transporte(passager));
        }
    }
}

