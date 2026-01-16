namespace SERIE02
{
    public class Personne
    {
        //attributs privés de la classe
        private string _nom;
        private double _taille;
        private int _age;
        public Personne(string nom, double taille, int age)
        {
            this._nom = nom;
            this._taille = taille;
            this._age = age;
        }
        /// <summary>
        /// Retourne ou définit le nom de la personne
        /// </summary>
        public string Nom { get => _nom; set => _nom = value; }
        /// <summary>
        /// Retourne ou définit la taille de la personne
        /// </summary>
        public double Taille { get => _taille; set => _taille = value; }
        /// <summary>
        /// Retourne ou définit l'age de la personne
        /// </summary>
        public int Age { get => _age; set => _age = value; }
        /// <summary>
        /// Compare cette personne à l'objet reçu en parametre et retourne TRUE uniquement si
        /// - l'objet reçu est de type Personne && les noms + taille + age sont identiques
        /// Retourne FALSE sinon ///
        /// </summary>
        /// <param name="obj">L'autre objet à comparer</param>
        /// <returns>True si c'est une personne avec le meme nom, taille et age</returns>
        public override bool Equals(object obj)
        {
            return obj is Personne personne &&
            _nom == personne._nom &&
            _taille == personne._taille &&
            _age == personne._age;
        }
        /// <summary>
        /// Retourne un texte represantant cette personne
        /// </summary>
        /// <returns>le nom suivi de la taille et de l'age</returns>
        public override string ToString()
        {
            return $"Nom: {_nom}, Taille: {_taille}, Age: {_age}";
        }
    }
}
