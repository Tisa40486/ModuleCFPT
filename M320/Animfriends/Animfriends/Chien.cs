namespace Animfriends
{
    public class Chien : Animal
    {
        private string _race;
        private string? _nomSoigneur;

        public Chien(string nom, string espece) : base(nom, espece)
        {
        }

        public Chien(string nom, string espece, string sexe, int taille, int poids, int age, string race, string nomSoigneur) : base(nom, espece, sexe, taille, poids, age)
        {
            Race = race;
            NomSoigneur = nomSoigneur;
        }
        public Chien(string nom, string espece, string sexe, int taille, int poids, int age, string race) : base(nom, espece, sexe, taille, poids, age)
        {
            Race = race;
            NomSoigneur = null;
        }

        public string Race { get => _race; set => _race = value; }
        public string? NomSoigneur { get => _nomSoigneur; set => _nomSoigneur = value; }
        private string Aboie()
        {
            return "OUAF !";
        }

        private string Grogne()
        {
            return "GRRRRRRRRRRRRRRRRRRR";
        }
        public string Comunique()
        {
            if (String.IsNullOrEmpty(NomSoigneur))
                return Grogne();

            return Aboie();
        }


        public override string ToString()
        {
            return $"Chien {Nom} ({Espece}, {Sexe}, {Age}mois, {Taille}cm, {Poids}gr) ";
        }
    }
}
