namespace Serie3
{
    public class Account
    {
        private int _numberAccount;
        private decimal _balance;

        public int NumberAccount
        {
            get => _numberAccount;
        }
        public decimal Balance
        {
            get => _balance;
        }

        public Account(int numberAccount, decimal balance)
        {
            _numberAccount = numberAccount;
            _balance = balance;
        }

        

        /// <summary>
        /// Add Money to the count if the amount is higher than zero.
        /// </summary>
        /// <param name="amount">int represent Amount</param>
        public void Deposer(decimal amount)
        {

            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Added {amount} to {_numberAccount}");
            }
            else
            {
                Console.WriteLine("Amount cannot be negative if you add money...");
            }
        }

        /// <summary>
        /// remove money to the count if the balance is superior than the amount.
        /// </summary>
        /// <param name="amount">int removed to the account</param>
        public void Retirer(decimal amount)
        {
            if (_balance > amount)
            {
                _balance -= amount;
                Console.WriteLine($"Removed {amount} to {_numberAccount}");
            }
            else
            {
                Console.WriteLine("Balance cannot be negative...");
            }
        }

        /// <summary>
        /// Show Balance to the specified account.
        /// </summary>
        public void GetBalance()
        {
            Console.WriteLine($"Balance of {_numberAccount} is : {_balance}");
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
