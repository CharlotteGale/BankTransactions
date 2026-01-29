/// <summary>
/// - Given a client makes a deposit of 1000 on 10-01-2023
/// - And a deposit of 2000 on 13-01-2023
/// - And a withdrawal of 500 on 14-01-2023
/// </summary>

public class BankAccount
{
    public List<Transaction> _transactions {get; set;} = new List<Transaction>();
    private decimal _balance = 0;

    public void Deposit(decimal amount)
    {
        _balance += amount;
        
        var record = new Transaction
        {
            Date = GetDate(),
            Credit = amount,
            Balance = _balance
        };

        _transactions.Add(record);
    }

    public void Withdraw(decimal amount)
    {
        _balance -= amount;
        var record = new Transaction
        {
            Date = GetDate(),
            Debit = amount,
            Balance = _balance
        };

        _transactions.Add(record);
    }

    public void PrintStatement()
    {
        Console.WriteLine($" {"date", -10} || {"credit", 10} || {"debit", 10} || {"balance", 10} ");

        foreach(Transaction transaction in _transactions.AsEnumerable().Reverse())
        {
            Console.WriteLine($" {transaction.Date, -10} || {transaction.Credit, 10:C} || {transaction.Debit, 10:C} || {transaction.Balance, 10:C} ");
        }
    }

    internal static DateOnly GetDate()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        return today;
    }
}