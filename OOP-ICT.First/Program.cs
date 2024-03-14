using OOP_ICT.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dealer dealer = new Dealer();
        List<Card> test = dealer.GetShuffledDeck();
        foreach (Card card in test)
        {
            Console.WriteLine(card);
        }
    }
}