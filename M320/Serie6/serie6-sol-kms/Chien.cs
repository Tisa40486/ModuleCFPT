namespace serie6_sol_kms
{
    public class Chien : Animal
    {

        private int _taille;
        public Chien(string nom, int poid) : base(nom, poid)
        {
        }

        public int Taille { get => _taille; set => _taille = value; }
    }
}
