using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Games.Component
{
    public partial class FundsDisplay
    {
        [Parameter]
        public decimal Funds { get; set; }

        [Parameter]
        public decimal Change { get; set; }
    }
}
