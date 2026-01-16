namespace SnackAttack
{
    public class Snack
    {
        private int _taille;

        
        public string Name;

        public int Taille { get => _taille; set => _taille = value; }

        public Snack(int taille, string name)
        {
            Taille = taille;
            Name = name;
        }

        public void Afficher()
        {
            string tailSnake = "<";
            string headSnake = "@@";
            string bodySnake = "";
            string snack = "";
         
            for (int i = 0; i < Taille; i++)
            {
                bodySnake += "#";
            }

            snack = tailSnake + bodySnake + headSnake;

            Console.WriteLine($"{Name} -> {snack}");
        }

        public void Attaquer(Snack snack, int degats)
        {
            Console.WriteLine($"{snack.Name} a etait attaquer ({snack.Taille} - {degats})");
            snack.Taille -= degats;
        }

    }
}
