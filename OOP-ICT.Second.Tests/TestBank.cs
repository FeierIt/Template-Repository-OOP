using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;
public class TestBank
{
    [Fact]
    public void TestBankTransferToPlayer()
    {
        decimal initialBalance = 100;
        Account account = new Account(initialBalance);
        Player player = new Player("Player4", account);
        Bank bank = new Bank();

        bank.TransferToPlayer(player, 28);

        Assert.Equal(128, account.Balance);
    }

    [Fact]
    public void TestBankTransferFromPlayer()
    {
        decimal initialBalance = 100;
        Account account = new Account(initialBalance);
        Player player = new Player("Player5", account);
        Bank bank = new Bank();

        bank.TransferFromPlayer(player, 80);

        Assert.Equal(20, account.Balance);
    }

    [Fact]
    public void TestBankCheckSufficientFunds()
    {
        decimal initialBalance = 100;
        Account account = new Account(initialBalance);
        Player player = new Player("Player6", account);
        Bank bank = new Bank();

        bool sufficientFunds1 = bank.CheckSufficientFunds(player, 50);
        bool sufficientFunds2 = bank.CheckSufficientFunds(player, 200);

        Assert.True(sufficientFunds1);
        Assert.False(sufficientFunds2);
    }
}