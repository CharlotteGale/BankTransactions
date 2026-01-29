namespace TransactionLog;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This is the Main Program");

        BankAccount bankAccount = new BankAccount();

        bankAccount.Deposit(1000);
        bankAccount.Deposit(2000);
        bankAccount.Withdraw(500);

        bankAccount.PrintStatement();
    }
}