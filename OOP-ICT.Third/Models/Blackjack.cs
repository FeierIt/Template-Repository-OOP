using OOP_ICT.Enums;
using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Models;

public class BlackjackGame
{
    private Dealer dealer;
    private List<Card> dealerHand;
    private BlackjackCasino casino;
    private Dictionary<Player, List<Card>> playerHands;
    private Dictionary<Player, decimal> playerBets;

    public BlackjackGame(Dealer dealer, BlackjackCasino casino)
    {
        this.dealer = dealer;
        this.casino = casino;
        playerHands = new Dictionary<Player, List<Card>>();
        playerBets = new Dictionary<Player, decimal>();
    }

    public void JoinGame(Player player)
    {
        if (!playerHands.ContainsKey(player))
        {
            playerHands.Add(player, new List<Card>());
            playerBets.Add(player, 0);
        }
        else
        {
            Console.WriteLine("Player is already in the game.");
        }
    }

    public void PlaceBet(Player player, decimal bet)
    {
        if (playerHands.ContainsKey(player))
        {
            if (player.Account.HasSufficientFunds(bet))
            {
                playerHands[player].Clear();
                playerBets[player] = bet;
                StartNewGame(player, bet);
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
        else
        {
            Console.WriteLine("Player is not in the game.");
        }
    }

    private void StartNewGame(Player player, decimal bet)
    {
        List<Card> playerHand = dealer.Deal(2);
        dealerHand = dealer.Deal(1);
        playerHands[player].AddRange(playerHand);

        Console.WriteLine($"Player's hand: {string.Join(", ", playerHand)}");
        Console.WriteLine($"Dealer's hand: {dealerHand[0]}, *");
    }

    public void Hit(Player player)
    {
        if (playerHands.ContainsKey(player))
        {
            List<Card> playerHand = playerHands[player];
            if (CalculatePoints(playerHand) < 21)
            {
                List<Card> additionalCards = dealer.Deal(1);
                playerHands[player].AddRange(additionalCards);
                Console.WriteLine($"Player's hand: {string.Join(", ", playerHands[player])}");
                if (CalculatePoints(playerHand) >= 21)
                {
                    Stand(player);
                }
            }
            else
            {
                Console.WriteLine("Player cannot hit, already has 21 or more points.");
            }
        }
        else
        {
            Console.WriteLine("Player is not in the game.");
        }
    }

    public void Stand(Player player)
    {
        if (playerHands.ContainsKey(player))
        {
            List<Card> playerHand = playerHands[player];
            while (CalculatePoints(dealerHand) < 17)
            {
                List<Card> additionalCards = dealer.Deal(1);
                dealerHand.AddRange(additionalCards);
            }
            Console.WriteLine($"Dealer's hand: {string.Join(", ", dealerHand)}");
            EvaluateGame(player);
        }
        else
        {
            Console.WriteLine("Player is not in the game.");
        }
    }

    private void EvaluateGame(Player player)
    {
        List<Card> playerHand = playerHands[player];

        int playerPoints = CalculatePoints(playerHand);
        int dealerPoints = CalculatePoints(dealerHand);

        decimal bet = playerBets[player];

        if (playerPoints > 21 || (dealerPoints <= 21 && dealerPoints > playerPoints))
        {
            Console.WriteLine("Player loses.");
            casino.DeductLoss(player, bet);
        }
        else if (playerPoints <= 21 && (dealerPoints > 21 || playerPoints > dealerPoints))
        {
            Console.WriteLine("Player wins.");
            casino.AwardWin(player, playerPoints == 21 ? 2.5m : 2 * bet);
        }
        else if (playerPoints == dealerPoints)
        {
            Console.WriteLine("Draw.");
            casino.AwardWin(player, playerPoints == 21 ? 1.5m : bet);
        }

        playerHands[player].Clear();
    }

    private int CalculatePoints(List<Card> hand)
    {
        int points = 0;
        int aceCount = 0;

        foreach (Card card in hand)
        {
            if (card.Rank == Rank.Jack || card.Rank == Rank.Queen || card.Rank == Rank.King)
            {
                points += 10;
            }
            else if (card.Rank == Rank.Ace)
            {
                points += 11;
                aceCount++;
            }
            else
            {
                points += (int)card.Rank;
            }
        }

        while (points > 21 && aceCount > 0)
        {
            points -= 10;
            aceCount--;
        }

        return points;
    }

    public List<Card> GetPlayerHand(Player player)
    {
        if (playerHands.ContainsKey(player))
        {
            return playerHands[player];
        }
        else
        {
            return new List<Card>();
        }
    }

    public List<Card> GetDealerHand()
    {
        return dealerHand;
    }

    public IEnumerable<Player> GetPlayers()
    {
        return playerHands.Keys;
    }

    public decimal GetPlayerBet(Player player)
    {
        if (playerBets.ContainsKey(player))
        {
            return playerBets[player];
        }
        else
        {
            return 0;
        }
    }
}