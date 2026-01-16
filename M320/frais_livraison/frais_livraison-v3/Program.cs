using CalculFrais;

namespace frais_livraison_v3
{

    public  class Program
    {
        /// <summary>
        /// Main content of the code, error management etc.
        /// </summary>
        static void Main()
        {
           
            bool continuer = true;
            bool checkpoid;
            bool checkKm;
            double coutLivraison = 5.0;
            double newCalc = 0.0;

            while (continuer == true)
            {
                Console.WriteLine("Entrez le poids du colis (en kg) :");
                string? resultPoid = Console.ReadLine();

                checkpoid = double.TryParse(resultPoid, out double poid);

                if (!checkpoid)
                    Console.WriteLine($"{resultPoid} not a valid input, please retry");

                Console.WriteLine("Entrez la distance de livraison (en km) :");
                string? resultKm = Console.ReadLine();

                checkKm = double.TryParse(resultKm, out double distance);

                if (!checkKm)
                    Console.WriteLine($"{resultKm} not a valid input, please retry");

                if (checkKm && checkpoid)
                {
                    newCalc = CalcCoutLivraison(coutLivraison, poid, distance);
                    Livraison.AfficherCoutLivraison(newCalc);
                    continuer = ValidateExecution();
                }
            }
        }

        /// <summary>
        /// Calculate the value of Delivery 
        /// </summary>
        /// <param name="coutLivraison"> the initiate double value</param>
        /// <param name="poid">Weight of the package</param>
        /// <param name="distance">Distances for the delivery</param>
        /// <returns> int : calculated livraison cost</returns>

        private static double CalcCoutLivraison(double coutLivraison, double poid, double distance) 
        {

            double coutLivraisonCalculé = coutLivraison;


            if (poid > 5)
                coutLivraisonCalculé = coutLivraison + 10; 
            
            if (distance > 50)
                coutLivraisonCalculé = coutLivraison + 5;

            return coutLivraisonCalculé;

        }

        /// <summary>
        /// Update the "continuer" value
        /// </summary>
        /// <returns>True/false depend on the user choice</returns>
        
        private static bool ValidateExecution()
        {
            Console.WriteLine("Do you want to restart ? yes/no");

            string? result = Console.ReadLine();

            if (result != null && result.ToUpper() == "YES")
                return true;
            

            if (result != null && result.ToUpper() == "NO")
                return false;

            Console.WriteLine("Error : Wrong input => default value to true");
            return true;
        }
    }
}