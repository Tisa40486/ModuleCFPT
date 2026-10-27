namespace geometrie
{
    /// <summary>
    /// Programme de démonstration : lancez-le pour voir Classer répondre.
    /// Les tests, eux, sont dans le projet Triangle.Tests (menu Test, Exécuter tous les tests).

    /// </summary>
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Afficher(3, 3, 3);
            Afficher(3, 3, 2);
            Afficher(3, 4, 5);
            Afficher(0, 4, 5);
            Afficher(1, 2, 3);
        }

        static void Afficher(int a, int b, int c)
        {
            Console.WriteLine($"Classer({a}, {b}, {c}) : {Triangle.Classer(a, b, c)}");
        }
    }
}
