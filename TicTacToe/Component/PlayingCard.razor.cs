using Games.Models;
using Microsoft.AspNetCore.Components;

namespace Games.Component
{
    public partial class PlayingCard
    {
        [Parameter]
        public Card Card { get; set; } = default!;
    }
}
