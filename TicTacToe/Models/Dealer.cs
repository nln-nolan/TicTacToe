namespace Games.Models
{
    public class Dealer : Person
    {
        public Deck Deck { get; set; } = new();

        public bool HasAceShowing => Cards.Count == 2
            && VisibleScore == 11
            && Cards.Any(x => x.IsVisible == false);

        public Card Deal()
        {
            return Deck.Draw();
        }

        public async Task DealToSelf()
        {
            await AddCard(Deal());
        }

        public async Task DealToPlayer(Player player)
        {
            await player.AddCard(Deal());
        }

        internal void Reveal()
        {
            Cards.ForEach(c => c.IsVisible = true);
        }
    }
}
