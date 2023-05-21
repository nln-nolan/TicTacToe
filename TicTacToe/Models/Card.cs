using Games.Abstractions;

namespace Games.Models
{
    public class Card
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }

        public int Score
        {
            get
            {
                if (IsTenValueCard)
                {
                    return 10;
                }
                if (Value == CardValue.Ace)
                {
                    return 11;
                }
                else
                {
                    return (int)Value;
                }
            }
        }

        public bool IsVisible { get; set; } = true;

        public bool IsTenValueCard
        {
            get
            {
                return Value == CardValue.Ten
                        || Value == CardValue.Jack
                        || Value == CardValue.Queen
                        || Value == CardValue.King;
            }
        }

        public string ImageTitle { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
    }
}
