namespace TestProject1;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        decimal beginningBalance = 11.99m;
        decimal debitAmount = 4.55m;
        decimal expected = 7.44m;
        BankAccount account = new BankAccount("Ms. Hai Som", beginningBalance);

        account.Withdraw(debitAmount);

        decimal actual = account.Balance;
        Assert.AreEqual(expected, actual, 0.001m, "Account not debited correctly");
    }
}
