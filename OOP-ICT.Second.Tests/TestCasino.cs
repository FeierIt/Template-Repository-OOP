using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;
public class TestCasino
{
    [Fact]
    public void TestCasinoWin()
    {

        decimal initialBalance = 100;
        Account account = new Account(initialBalance);
        Player player = new Player("Player", account);
        BlackjackCasino casino = new BlackjackCasino();

        casino.AwardWin(player, 28);

        Assert.Equal(128, account.Balance);
    }

    [Fact]
    public void TestCasinoLoss()
    {
        decimal initialBalance = 100;
        Account account = new Account(initialBalance);
        Player player = new Player("Player", account);
        BlackjackCasino casino = new BlackjackCasino();

        casino.DeductLoss(player, 80);

        Assert.Equal(20, account.Balance);
    }

    [Fact]
    public void TestCasinoHandleBlackjack()
    {
        // Arrange
        decimal initialBalance = 100;
        Account account = new Account(initialBalance);
        Player player = new Player("Player3", account);
        BlackjackCasino casino = new BlackjackCasino();

        casino.HandleBlackjack(player, 10);

        Assert.Equal(115, account.Balance);
    }
}