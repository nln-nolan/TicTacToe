using Games.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Games.Component
{
    public partial class Message
    {
        [Parameter]
        public GameState State { get; set; }

        [Parameter]
        public decimal Bet { get; set; }
    }
}
