using System;
using System.Collections.Generic;
using System.Text;
using WarShip.Model;

namespace WarShip.View
{
    public static class CellView
    {
        public static char Sea { get; } = '▒';
        public static char Hit { get; } = 'X';
        public static char Miss { get; } = '▓';
    }
}
