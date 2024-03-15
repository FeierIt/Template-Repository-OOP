using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;
public class TestAccount
{
    [Fact]
    public void TestAccountDeposit()
    {
        decimal initialBalance = 100;
        Account account = new Account(initialBalance);

        account.Deposit(10);

        Assert.Equal(110, account.Balance);
    }

    [Fact]
    public void TestAccountWithdraw()
    {
        decimal initialBalance = 100;
        Account account = new Account(initialBalance);

        account.Withdraw(60);

        Assert.Equal(40, account.Balance);
    }

    [Fact]
    public void TestAccountHasSufficientFunds()
    {
        decimal initialBalance = 100;
        Account account = new Account(initialBalance);

        bool sufficientFunds1 = account.HasSufficientFunds(50);
        bool sufficientFunds2 = account.HasSufficientFunds(200);

        Assert.True(sufficientFunds1);
        Assert.False(sufficientFunds2);
    }
}