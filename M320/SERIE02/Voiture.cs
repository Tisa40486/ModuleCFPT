namespace SERIE02
{
    class Voiture
    {
        //les attribut privés de la classe
        private string _marque;
        private string _couleur;
        //constructeur des objets
        /// <summary>
        /// Constructeur d'une nouvelle instance de voiture.
        /// </summary>
        /// <param name="marque">La marque de la voiture : string</param>
        /// <param name="couleur">La couleur de la voiture : string</param>
        public Voiture(string marque, string couleur)
        {
            this.Marque = marque;
            this.Couleur = couleur;
        }
        //Getteurs et setteurs
        /// <summary>
        /// Retourne ou définit la marque de la voiture
        /// </summary>
        public string Marque { get => _marque; set => _marque = value; }
        /// <summary>
        /// Retourne ou définit la couleur de la voiture
        /// </summary>
        public string Couleur { get => _couleur; set => _couleur = value; }
        //Méthodes de l'objet
        /// <summary>
        /// Retourne un texte indiquant que la voiture roule et est conduite par la Personne reçue en paramètre
        /// </summary>
        /// <param name="conducteur">Le conducteur : Personne</param>
        /// <returns>un text contenant le nom du conducteur : string</returns>
        public string Roule(Personne conducteur)
        {
            return "La voiture roule et est conduite par " + conducteur.Nom;
        }
        /// <summary>
        /// Retourne un texte indiquant que la voiture transporte la personne reçue en paramère
        /// </summary>
        /// <param name="passager">Le passager : Personne</param>
        /// <returns>un text contenant le nom du passager : string</returns>
        public string Transporte(Personne passager)
        {
            return $"La voiture transporte le passager {passager.Nom}";
        }

        /// <summary>
        /// Retourne un texte qui represente cette voiture
        /// <returns>un text contenant la marque et la couleur de la voiture : string</returns>
        public override string ToString()
        {
            return $"La voiture est de marque {_marque} et de couleur {_couleur}";
        }
        /// <summary>
        /// Compare cette voiture à l'objet reçu en paramètre
        /// </summary>
        /// <param name="obj">L'autre objet à comparer</param>
        /// <returns>TRUE si l'objet reçue est de type voiture && s'il a la même marque && s'il a la même couleur ;
        ///FALSE si non</return>
        public override bool Equals(object obj)
        {
            return obj is Voiture voiture &&
            _marque == voiture._marque &&
            _couleur == voiture._couleur;
        }
    }
}
