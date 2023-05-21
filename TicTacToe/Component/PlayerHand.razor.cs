using Games.Models;
using Microsoft.AspNetCore.Components;

namespace Games.Component
{
    public partial class PlayerHand
    {
        [Parameter]
        public List<Card> Cards { get; set; } = new();
    }
}
