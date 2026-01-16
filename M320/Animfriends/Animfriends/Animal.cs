namespace Animfriends
{
    public class Animal
    {
        private string _nom;
        private string _espece;
        private string _sexe;
        private int _taille;
        private int _poids;
        private int _age;

        public Animal(string nom, string espece, string sexe, int taille, int poids, int age)
        {
            Nom = nom;
            Espece = espece;
            Sexe = sexe;
            Taille = taille;
            Poids = poids;
            Age = age;
        }

        public string Nom { get => _nom; set => _nom = value; }
        public string Espece { get => _espece; set => _espece = value; }
        public string Sexe { get => _sexe; set => _sexe = value; }
        public int Taille { get => _taille; set => _taille = value; }
        public int Poids { get => _poids; set => _poids = value; }
        public int Age { get => _age; set => _age = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom">Le nom de l'animal</param>
        /// <param name="espece">l'espece de l'animal</param>
        public Animal(string nom, string espece): this(nom, espece, "Inconnu", 1, 0, 0)
        { }



        /// <summary>
        /// retourne le texte de l'animal
        /// </summary>
        /// <returns>le string $"{Nom} ({Espece}, {Sexe}, {Age}mois, {Taille}cm, {Poids}gr) "</returns>
        public override string ToString()
        {
            return $"{Nom} ({Espece}, {Sexe}, {Age}mois, {Taille}cm, {Poids}gr) ";
        }
    }
}