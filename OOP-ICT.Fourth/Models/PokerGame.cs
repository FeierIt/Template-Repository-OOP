using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ICT.Fourth.Models;
public class PokerGame
{
    private Dealer dealer;
    private List<Player> players;
    private Bank bank;
    private Dictionary<Player, List<Card>> playerHands;
    private Dictionary<Player, decimal> playerBets;

    public PokerGame(List<Player> players)
    {
        this.players = players;
        dealer = new Dealer();
        bank = new Bank();
        playerHands = new Dictionary<Player, List<Card>>();
        playerBets = new Dictionary<Player, decimal>();
        foreach (var player in players)
        {
            playerHands[player] = new List<Card>();
        }
    }

    public void StartNewGame()
    {
        var rnd = new Random();
        for (int i = 0; i < rnd.Next(1, 100); i++) { }
        dealer.ShuffleDeck();
    }

    public void DealCards()
    {
        foreach (var player in players)
        {
            playerHands[player].Clear();
            playerHands[player].AddRange(dealer.Deal(2));
        }
    }

    public void AcceptBets(List<decimal> bets)
    {
        if (bets == null || bets.Count != players.Count)
            throw new ArgumentException("Invalid bets provided.");

        for (int i = 0; i < players.Count; i++)
        {
            decimal bet = bets[i];
            if (!players[i].Account.HasSufficientFunds(bet))
                throw new InvalidOperationException($"Player {players[i].Name} doesn't have enough funds to place the bet.");
            playerBets[players[i]] = bet;
        }
    }


    public void CompareHands()
    {
        List<Player> losers = new List<Player>();
        foreach (var player in players)
        {
            if (!playerHands.ContainsKey(player))
            {
                continue;
            }
            List<Card> playerHand = playerHands[player];
            Console.WriteLine($"{player.Name}'s hand: {string.Join(", ", playerHand)}");

            PokerHand playerPokerHand = new PokerHand(playerHand);
            PokerHand dealerPokerHand = new PokerHand(dealer.GetShuffledDeck().Take(5).ToList());

            int result = playerPokerHand.CompareTo(dealerPokerHand);
            if (result < 0)
                losers.Add(player);
            else if (result == 0)
            {
                Console.WriteLine($"{player.Name} has the same hand as dealer. It's a tie.");
            }
            else
            {
                Console.WriteLine($"{player.Name} has a better hand than dealer. Win.");
                bank.TransferToPlayer(player, playerBets[player]);
            }
        }
        DeductLosses(losers);
    }

    private void DeductLosses(List<Player> losers)
    {
        foreach (var loser in losers)
        {
            Console.WriteLine($"{loser.Name} lost.");
            decimal betLost = playerBets[loser];
            bank.TransferFromPlayer(loser, betLost);
            Console.WriteLine($"Player {loser.Name} lost {betLost}.");
        }
    }

    public void SetPlayerHand(Player player, List<Card> hand)
    {
        if (!players.Contains(player))
            throw new ArgumentException("Player is not part of the game.");
        playerHands[player] = hand;
    }
}
