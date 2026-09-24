
    // Exercice 1, etape 2 : la version orientee objet.
    public class Statistique
    {
        private readonly List<Voiture> _catalogue;

        public Statistique(List<Voiture> catalogue)
        {
            _catalogue = catalogue;
        }

        public int NombreVoitureParCarburant(string carburant)
        {
            // A COMPLETER exercice 1, etape 2
            // Indice : la boucle reste a l'interieur de l'objet.
            int number = 0;
            foreach(Voiture v in _catalogue)
            {
                if (v.Carburant == carburant)
                    number++;
            }
            return number;
        }

        public int ValeurVoitureParCarburant(string carburant)
        {
            // A COMPLETER exercice 1, etape 2
            int valeur = 0;
            foreach (Voiture v in _catalogue)
            {
                if (v.Carburant == carburant)
                    valeur += v.Prix;
            }
            return valeur;
        }
    }

