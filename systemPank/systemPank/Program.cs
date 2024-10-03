namespace systemPank
{
    public class AccountUtil
    {
        // Utility helper functions for Account class

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc.name);
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.name}");
            }
        }



    }
    public class Account
    {
        
        Account(string _name = " ", double _balnce = 0.0)
        {
            name = _name;
            balnce = _balnce;
        }
        public string name { get; set; }
        public double balnce { get; set; }
        Account()
        {

        }
        public static Account operator +(Account a, Account b)
        {
            Account account = new Account() { name = a.name, balnce = a.balnce + b.balnce };
            return account;
        }
       
        public void Display(Account text)
        {
            Console.WriteLine(text.name);
            Console.WriteLine(text.balnce);
        }
        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balnce += amount;
                return true;
            }
            return false;
        }
        public virtual bool Withdraw(double amount)
        {
            if (amount - amount >= 0)
            {
                balnce -= amount;
                return true;

            }
            return false;
        }
    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(string name = " ", double balnce = 0.0, double instrate = 0)
            : base(name, balnce)
        {
            Instrate = instrate;
        }

        public double Instrate { get; set; }

      
        public override bool Deposit(double amount)
        {

            if (amount > 0)
            {
                balnce += amount;
                return true;
            }
            return false;
        }
        public override bool Withdraw(double amount)
        {
            if (amount - amount >= 0)
            {
                balnce -= amount;
                return true;

            }
            return false;
        }
    }
    public class CheckingAccount : Account
    {
        public CheckingAccount(string _name = " ", double _balnce = 0.0)
        {
            
        }
        public override bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balnce += amount;
                return true;
            }
            return false;
        }
        public override bool Withdraw(double amount)
        {
            if (amount - amount >= 0)
            {

                balnce -= (amount + 1.5);
                return true;
            }
            return false;
        }
    }
    public class TrustAccount : SavingsAccount
    {
        public TrustAccount(string name = " ", double balnce = 0.0, double instrate = 0)
           : base(name, balnce, instrate)
        {

        }
        public override bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balnce += (amount + 50);
                return true;
            }

            else if  (amount <= 5000)
            {
                balnce += amount;
                return true;
            }
            return false;
               
        }
        public override bool Withdraw(double amount)
        {
            if (balnce * (20 / 100) <= amount)
            {
                balnce -= amount;
                return true;
            }
            return false;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
                // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Display(accounts);
            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<Account>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Display(savAccounts);
            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            var checAccounts = new List<Account>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Display(checAccounts);
            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<Account>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Display(trustAccounts);
            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();
            Account account = new Account();
            Account account1 = new Account();
            Account account2 = account + account1;

            Console.WriteLine(account2);
        }


    }
}
