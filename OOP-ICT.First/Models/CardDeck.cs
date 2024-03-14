﻿using OOP_ICT.Enums;

namespace OOP_ICT.Models;

public class CardDeck
{
    private List<Card> cards;

    public CardDeck()
    {
        Initialize();
    }

    private void Initialize()
    {
        cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }
        cards.Reverse();
    }

    public void Shuffle()
    {
        int n = cards.Count;
        int half = n / 2;
        for (int j = 0; j < 7; j++)
        {
            List<Card> shuffledDeck = new List<Card>();

            for (int i = 0; i < half; i++)
            {
                shuffledDeck.Add(cards[i]);
                shuffledDeck.Add(cards[i + half]);
            }

            cards = shuffledDeck;
            Console.WriteLine(cards[5]);
        }
    }

    public List<Card> GetCards()
    {
        return cards;
    }
}