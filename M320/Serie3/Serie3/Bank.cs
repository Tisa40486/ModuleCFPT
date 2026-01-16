
namespace Serie3
{
    public class Bank
    {

        private List<Account> _accounts;
        public Bank(List<Account> accounts)
        {
            _accounts = accounts;
        }


        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public Account? FindAccount(int numberAccount)
        {
            foreach (var item in _accounts)
            {
                if (item.NumberAccount == numberAccount)
                {
                    return item;
                }
            }

            return null;
        }

        public void DisplayAccount()
        {
            foreach(var item in _accounts)
            {
                Console.WriteLine($"Infos of {item.NumberAccount} -> Balance : CHF -.{item.Balance}");
            }
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
