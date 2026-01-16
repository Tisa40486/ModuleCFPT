namespace Animfriends
{
    public class Chat : Animal
    {
        private string _race;
        public string Race { get => _race; set => _race = value; }
        public Chat(string nom, string espece, string sexe, int taille, int poids, int age, string race) : base(nom, espece, sexe, taille, poids, age)
        {
            Race = race;
        }

        private string Mieulle()
        {
            return "Miaouuuuuuuuuuuuuuuuuuuuuuuuuu";
        }

        private string Grogne()
        {
            return "Kriiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiirrrrrrr";
        }

        public string Comunique(Boolean content)
        {
            if (content)
                return Mieulle();

            return Grogne();
        }

        public override string ToString()
        {
            return $"Chat {Nom} ({Espece}, {Sexe}, {Age}mois, {Taille}cm, {Poids}gr) ";
        }
    }
}