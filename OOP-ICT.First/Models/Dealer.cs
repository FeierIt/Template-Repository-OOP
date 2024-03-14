namespace OOP_ICT.Models;

public class Dealer
{
    private CardDeck deck;

    public Dealer()
    {
        deck = new CardDeck();
    }

    public List<Card> Deal(int numberOfCards)
    {
        List<Card> dealtCards = new List<Card>();
        for (int i = 0; i < numberOfCards; i++)
        {
            if (deck.GetCards().Count == 0)
            {
                deck = new CardDeck();
                deck.Shuffle();
            }

            dealtCards.Add(deck.GetCards()[0]);
            deck.GetCards().RemoveAt(0);
        }
        return dealtCards;
    }

    public void ShuffleDeck()
    {
        deck.Shuffle();
    }

    public List<Card> GetShuffledDeck()
    {
        deck.Shuffle();
        return deck.GetCards();
    }
}