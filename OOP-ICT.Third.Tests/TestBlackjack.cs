using OOP_ICT.Enums;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Models;
using Xunit;

namespace OOP_ICT.Third.Tests;
public class BlackjackGameTests
{
    [Fact]
    public void JoinGame_AddsPlayerToGame()
    {
        var dealer = new Dealer();
        var casino = new BlackjackCasino();
        var game = new BlackjackGame(dealer, casino);
        var acc = new Account(100);
        var player = new Player("Andrey", acc);

        game.JoinGame(player);

        Assert.Contains(player, game.GetPlayers());
    }

    [Fact]
    public void PlaceBet_PlacesBetForPlayer()
    {
        var dealer = new Dealer();
        var casino = new BlackjackCasino();
        var game = new BlackjackGame(dealer, casino);
        var acc = new Account(100);
        var player = new Player("Andrey", acc);
        game.JoinGame(player);
        decimal bet = 50;

        game.PlaceBet(player, bet);

        Assert.Equal(bet, game.GetPlayerBet(player));
    }

    [Fact]
    public void BalanceUpdatedAfterGame()
    {
        var dealer = new Dealer();
        var casino = new BlackjackCasino();
        var game = new BlackjackGame(dealer, casino);
        decimal balance = 100;
        var acc = new Account(balance);
        var player = new Player("Andrey", acc);
        game.JoinGame(player);
        decimal bet = 50;

        game.PlaceBet(player, bet);
        game.Stand(player);

        Assert.NotEqual(balance, player.Account.Balance);
    }
}