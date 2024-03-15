using OOP_ICT.Fourth.Enum;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models;
public class PokerHand : IComparable<PokerHand>
{
    public List<Card> Cards { get; }

    public PokerHand(List<Card> cards)
    {
        Cards = cards;
    }

    public int CompareTo(PokerHand other)
    {
        HandRank rank = GetHandRank(this.Cards);
        HandRank otherRank = GetHandRank(other.Cards);

        if (rank != otherRank)
            return rank.CompareTo(otherRank);

        return CompareHighCards(this.Cards, other.Cards);
    }

    private HandRank GetHandRank(List<Card> cards)
    {
        if (IsStraightFlush(cards))
            return HandRank.StraightFlush;
        if (IsFourOfAKind(cards))
            return HandRank.FourOfAKind;
        if (IsFullHouse(cards))
            return HandRank.FullHouse;
        if (IsFlush(cards))
            return HandRank.Flush;
        if (IsStraight(cards))
            return HandRank.Straight;
        if (IsThreeOfAKind(cards))
            return HandRank.ThreeOfAKind;
        if (IsTwoPair(cards))
            return HandRank.TwoPair;
        if (IsPair(cards))
            return HandRank.Pair;

        return HandRank.HighCard;
    }

    private bool IsFlush(List<Card> cards)
    {
        return cards.GroupBy(c => c.Suit).Any(grp => grp.Count() == 5);
    }

    private bool IsStraight(List<Card> cards)
    {
        var orderedCards = cards.OrderBy(c => (int)c.Rank).ToList();
        bool straight = true;
        for (int i = 0; i < orderedCards.Count - 1; i++)
        {
            if ((int)orderedCards[i + 1].Rank - (int)orderedCards[i].Rank != 1)
            {
                straight = false;
                break;
            }
        }
        return straight;
    }

    private bool IsStraightFlush(List<Card> cards)
    {
        return IsFlush(cards) && IsStraight(cards);
    }

    private bool IsFourOfAKind(List<Card> cards)
    {
        return cards.GroupBy(c => c.Rank).Any(grp => grp.Count() == 4);
    }

    private bool IsFullHouse(List<Card> cards)
    {
        return IsThreeOfAKind(cards) && IsPair(cards);
    }

    private bool IsThreeOfAKind(List<Card> cards)
    {
        return cards.GroupBy(c => c.Rank).Any(grp => grp.Count() == 3);
    }

    private bool IsTwoPair(List<Card> cards)
    {
        int pairsCount = cards.GroupBy(c => c.Rank).Count(grp => grp.Count() == 2);
        return pairsCount == 2;
    }

    private bool IsPair(List<Card> cards)
    {
        return cards.GroupBy(c => c.Rank).Any(grp => grp.Count() == 2);
    }

    private int CompareHighCards(List<Card> cards1, List<Card> cards2)
    {
        var sorted1 = cards1.OrderByDescending(c => c.Rank).ToList();
        var sorted2 = cards2.OrderByDescending(c => c.Rank).ToList();

        for (int i = 0; i < sorted1.Count; i++)
        {
            int comparison = sorted1[i].Rank.CompareTo(sorted2[i].Rank);
            if (comparison != 0)
                return comparison;
        }

        return 0;
    }
}