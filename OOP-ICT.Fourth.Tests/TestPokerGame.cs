using OOP_ICT.Enums;
using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Fourth.Tests;
public class PokerGameTests
{
    [Fact]
    public void TestGame()
    {
        var players = new List<Player>
            {
                new Player("Player1", new Account(100)),
                new Player("Player2", new Account(100)),
                new Player("Player3", new Account(100))
            };
        var pokerGame = new PokerGame(players);

        pokerGame.StartNewGame();
        pokerGame.DealCards();
        pokerGame.AcceptBets(new List<decimal> { 10, 20, 30 }); 
        pokerGame.CompareHands();

        foreach (var player in players)
        {
            Assert.True(player.Account.Balance >= 0);
        }
    }
}