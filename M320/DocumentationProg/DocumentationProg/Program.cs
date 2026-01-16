namespace DocumentationProg
{
    public  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           
            Console.WriteLine(NbPersonne("Bonjour nous sommes:"));
        }

        /// <summary>
        /// retourne le nombre de personne dans la classe
        /// </summary>
        /// <param name="greetings">entre une phrase d'acceuil</param>
        /// <returns>int: nombre personne</returns>
        private static string NbPersonne(string greetings)
        {
            return $"{greetings} 12";
        }
    }
}