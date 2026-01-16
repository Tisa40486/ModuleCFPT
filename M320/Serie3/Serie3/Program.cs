namespace Serie3
{

    /// <summary>
    /// Projet: Gestion de Banque et Comptes
    /// Détails: Dans cet exercice, vous allez implémenter un programme de gestion de comptes bancaires. Une banque peut gérer plusieurs comptes clients, et chaque compte possède un solde et permet des opérations de dépôt et de retrait.
    /// Auteur: Mattis Lefranc-Adam
    /// Date: 21/11/25
    /// </summary>


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();

            // Random montant de compte pour données dense
            Random rnd = new Random();
            int amount = rnd.Next(0, 500000);



            int numberOfAccount = 20;
            int numberAccount = 0;
            // Ajout automatique de compte
            for (int i = 0; i < numberOfAccount; i++)
            {
                amount = rnd.Next(0, 500000);

                Account account1 = new Account(numberAccount, amount);

                accounts.Add(account1);
                numberAccount++;
            }

            Bank bank = new Bank(accounts);

            bank.DisplayAccount();



            //test


            //Ajout money
            bank.FindAccount(3).Deposer(250);
            bank.FindAccount(3).GetBalance();

            //Retrait Money
            bank.FindAccount(3).Retirer(3000);
            bank.FindAccount(3).GetBalance();

            bank.FindAccount(58).Deposer(250);
            bank.FindAccount(58).GetBalance();

            //Retrait Money
            bank.FindAccount(58).Retirer(3000);
            bank.FindAccount(58).GetBalance();

        }
    }
}
