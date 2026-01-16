namespace SnackAttack
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Random tailleBody = new Random();
            Random degats = new Random();

            int nmbSnack = tailleBody.Next(3, 11);
            int nmbSnack1 = tailleBody.Next(3, 11);

            int nmbDegats = degats.Next(0, 3);
            int nmbDegats1 = degats.Next(0, 3);

            Snack snack = new Snack(nmbSnack, "snack");
            Snack snack1 = new Snack(nmbSnack1, "snack1");

            snack.Afficher();
            snack1.Afficher();

            Console.WriteLine();
            while (snack.Taille > 0 && snack1.Taille > 0)
            {


                nmbDegats = degats.Next(0, 4);
                nmbDegats1 = degats.Next(0, 4);



                snack.Attaquer(snack1, nmbDegats);
                snack1.Afficher();

                snack1.Attaquer(snack, nmbDegats1);
                snack.Afficher();
            }

            if (snack.Taille == 0)
            {
                Console.WriteLine($"{snack1.Name} a gagné");
                snack1.Afficher();
            }
            else
            {
                Console.WriteLine($"{snack.Name} a gagné");
                snack.Afficher();
            }
        }
    }
}