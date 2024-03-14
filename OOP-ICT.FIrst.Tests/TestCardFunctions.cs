using OOP_ICT.Enums;
using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    /// <summary>
    /// Тесты пишутся из трех частей итог - данные - что вернуло 
    /// </summary>
    [Fact]
    public void Dealer_GetShuffledDeck_Contain_AllCards()
    {
        Dealer dealer = new Dealer();
        List<Card> shuffledDeck = dealer.GetShuffledDeck();

        Assert.Equal(52, shuffledDeck.Count);
    }

    [Fact]
    public void Card_ToString()
    {
        Card card = new Card(Suit.Hearts, Rank.Ace);
        string cardString = card.ToString();

        Assert.Equal("Ace of Hearts", cardString);
    }

    [Fact]
    public void CardDeck_Shuffle_Should_Shuffle_Cards()
    {
        CardDeck deck = new CardDeck();
        List<Card> originalDeck = new List<Card>(deck.GetCards());

        deck.Shuffle();
        List<Card> shuffleDeck = deck.GetCards();

        Assert.NotEqual(originalDeck, shuffleDeck);
    }
}