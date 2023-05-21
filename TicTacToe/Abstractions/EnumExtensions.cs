using System.Net.NetworkInformation;
using System.Threading;

namespace Games.Abstractions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this CardSuit cardSuit)
        {
            switch (cardSuit)
            {
                case CardSuit.Hearts:
                    return "Hearts";
                case CardSuit.Clubs:
                    return "Clubs";
                case CardSuit.Diamonds:
                    return "Diamonds";
                case CardSuit.Spades:
                    return "Spades";
                default:
                    return string.Empty;
            }
        }

        public static string GetDisplayName(this CardValue cardValue)
        {
            switch (cardValue)
            {
                case CardValue.Ace:
                    return "Ace";
                case CardValue.Two:
                    return "Two";
                case CardValue.Three:
                    return "Three";
                case CardValue.Four:
                    return "Four";
                case CardValue.Five:
                    return "Five";
                case CardValue.Six:
                    return "Six";
                case CardValue.Seven:
                    return "Seven";
                case CardValue.Eight:
                    return "Eight";
                case CardValue.Nine:
                    return "Nine";
                case CardValue.Ten:
                    return "Ten";
                case CardValue.Jack:
                    return "Jack";
                case CardValue.Queen:
                    return "Queen";
                case CardValue.King:
                    return "King";

                default:
                    return string.Empty;
            }
        }
    }
}
