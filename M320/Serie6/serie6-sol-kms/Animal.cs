namespace serie6_sol_kms
{
    public class Animal
    {
        private string _nom;
        private int _poid;

        public string Nom { get => _nom; set => _nom = value; }
        public int Poid { get => _poid; set => _poid = value; }
        public Animal(string nom, int poid)
        {
            _nom = nom;
            _poid = poid;
        }
        

        /// <summary>
        /// Un animal est égal à un autre animal SSI l'autre est aussi un Animal, avec le même nom et le même poids
        /// </summary>
        /// <param name="obj">l'autre animal à comparer à celui-ci</param>
        /// <returns>TRUE si other est un object de type Animal avec le même nom et le même poids</returns>

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Animal))
                return false;

            if (Nom == ((Animal)obj).Nom && Poid == ((Animal)obj).Poid)
                return true;

            return false;
        }   

        /// <summary>
        /// Le texte représentant un animal est composé de son Nom (poids)
        /// </summary>
        /// <returns>Un string représentant l'animal. Exemple : "Toto (poids : 20gr)" </returns>

        public override string? ToString()
        {
            return $"{Nom} (poids : {Poid}gr)";
        }
    }
}
