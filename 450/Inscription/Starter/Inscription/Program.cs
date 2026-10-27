using Inscription;

// Programme de démonstration : lancez-le pour voir la classe User répondre.
// Les tests, eux, sont dans le projet Inscription.Tests (menu Test, Exécuter tous les tests).
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        User user = new User("ana@exemple.ch", "Secret!2026");
        Console.WriteLine($"E-mail : {user.Email}");

        // TODO exercice 3 : affichez IsActive à la création, après Activate(), puis après Deactivate().
        // Sortie attendue, sous la ligne de l'e-mail : False, True, False, une valeur par ligne.
    }
}
