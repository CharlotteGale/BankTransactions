namespace TransactionLog.Tests;

[TestFixture]
public class BankAccountTests
{
    private BankAccount _bankAccount;
    
    [SetUp]
    public void PointOfEntry()
    {
        _bankAccount = new BankAccount();
    }
    [Test]
    public void DepositAmount_WhenCalled_CreditsAccountWithGivenAmount()
    {
        _bankAccount.Deposit(500);

        var record = _bankAccount._transactions.Last();

        Assert.Multiple(() =>
        {
            Assert.That(record.Credit, Is.EqualTo(500));
            Assert.That(record.Balance, Is.EqualTo(500));
        });
    }

    [Test]
    public void WithdrawAmount_WhenCalled_DebitsAccountWithGivenAmount()
    {
        _bankAccount.Deposit(500);

        _bankAccount.Withdraw(250);

        var record = _bankAccount._transactions.Last();

        Assert.Multiple(() =>
        {
            Assert.That(record.Debit, Is.EqualTo(250));
            Assert.That(record.Balance, Is.EqualTo(250));
        });
    }
}