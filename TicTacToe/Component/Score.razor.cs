using Games.Abstractions;
using Games.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Games.Component
{
    public partial class Score
    {
        [Parameter]
        public GameState State { get; set; }

        [Parameter]
        public Person Player { get; set; } = default!;
    }
}
