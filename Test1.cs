namespace TestProject1;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        // Constructor Test
        decimal startingBal = 876m;
        BankAccount test = new BankAccount("hanover", startingBal);

        Assert.AreEqual(startingBal, test.Balance, "Bank Account Constructor Failed");
    }

    [TestMethod]
    public void TestMethod2()
    {
        // Deposit Test
        decimal depositAmount = 500m;

        BankAccount test = new BankAccount("ackee", 1100m);
        test.Deposit(depositAmount);

        Assert.AreEqual(1100m + 500m, test.Balance);

        var transactions = test.Transactions;
        Assert.AreEqual("Deposited: $500.00, New Balance: $1,600.00", transactions[1]);

        Assert.ThrowsException<ArgumentException>(() => test.Deposit(-100m));

    }

    [TestMethod]
    public void TestMethod3()
    {
        // Withdraw Test
        decimal withdrawAmount = 200m;

        BankAccount test = new BankAccount("ackee", 1100m);
        test.Withdraw(withdrawAmount);

        Assert.AreEqual(1100m - 200m, test.Balance);

        var transactions = test.Transactions;
        Assert.AreEqual("Withdrew: $200.00, New Balance: $900.00", transactions[1]);

        Assert.ThrowsException<ArgumentException>(() => test.Deposit(-100m));
        Assert.ThrowsException<InvalidOperationException>(() => test.Withdraw(1000000m));
    }

    [TestMethod]
    public void TestMethod4()
    {
        // Transaction History Test
        BankAccount test = new BankAccount("ackee", 1100m);
        test.Deposit(500m);
        test.Withdraw(200m);

        var transactions = test.Transactions;

        Assert.AreEqual(3, transactions.Count);
        Assert.AreEqual("Account created for ackee with initial balance: $1,100.00", transactions[0]);
        Assert.AreEqual("Deposited: $500.00, New Balance: $1,600.00", transactions[1]);
        Assert.AreEqual("Withdrew: $200.00, New Balance: $1,400.00", transactions[2]);
    }

    [TestMethod]
    public void TestMethod5()
    {
        //Account Balance Test
        BankAccount test = new BankAccount("ackee", 1100m);
        Assert.AreEqual(1100m, test.Balance);

        test.Deposit(500m);
        Assert.AreEqual(1600m, test.Balance);

        test.Withdraw(200m);
        Assert.AreEqual(1400m, test.Balance);
    }

}
