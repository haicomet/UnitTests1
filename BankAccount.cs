using System;
using System.Collections.Generic;

public class BankAccount
{
    private int accountId;
    string customerName;
    decimal balance;
    List<string> transactions;

    public BankAccount(string customerName, decimal initialBalance)
    {
        if (initialBalance < 0) throw new  ArgumentException("Initial balance cannot be negative.");
        if (string.IsNullOrWhiteSpace(customerName)) throw new  ArgumentException("Customer name cannot be empty.");

        this.accountId = new Random().Next(1000, 9999);
        this.customerName = customerName;
        this.balance = initialBalance;
        this.transactions = new List<string>();
        transactions.Add($"Account created for {customerName} with initial balance: {initialBalance:C}");
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new  ArgumentException("Deposit amount must be positive.");
        balance += amount;
        transactions.Add($"Deposited: {amount:C}, New Balance: {balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new  ArgumentException("Withdrawal amount must be positive.");
        if (amount > balance) throw new  InvalidOperationException($"Insufficient funds for this withdrawal. Current balance: {balance:C}");
        balance -= amount;
        transactions.Add($"Withdrew: {amount:C}, New Balance: {balance:C}");
    }

    public int AccountId { get { return accountId; } }
    public string CustomerName { get { return customerName; } }
    public decimal Balance { get { return balance; } }
    public List<string> Transactions { get { return transactions; } }
}

/*
public class Program
{
    public static void Main(string[] args)
    {
        // Test case 1: Create account with valid initial balance
        BankAccount account = new BankAccount("Snoh Aalegra", 1000);
        Console.WriteLine($"Account created for {account.CustomerName} \n Account Number: {account.AccountId} \n Initial Balance: {account.Balance:C}\n");

        // Test case 2: Deposit valid amount
        account.Deposit(500);
        Console.WriteLine($"{account.CustomerName} deposited 500. New Balance: {account.Balance:C}");

        // Test case 3: Withdraw valid amount
        account.Withdraw(150.20m);
        Console.WriteLine($"{account.CustomerName} withdrew 150.20. New Balance: {account.Balance:C}");

        // Test case 4: Attempt to withdraw more than balance
        try
        {
            account.Withdraw(2000);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Test case 5: Attempt to deposit negative amount
        try
        {
            account.Deposit(-100);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Test case 6: Attempt to withdraw negative amount
        try
        {
            account.Withdraw(-50);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Display all transactions
        Console.WriteLine("\nTransaction History:");
        foreach (var transaction in account.Transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}
*/