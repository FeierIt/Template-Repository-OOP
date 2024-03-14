namespace OOP_ICT.Second.Models;

public class Account
{
    public decimal Balance { get; private set; }

    public Account(decimal balance)
    {
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }

    public bool HasSufficientFunds(decimal amount)
    {
        return Balance >= amount;
    }
}