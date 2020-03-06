using System;
using System.Collections.Generic;
using System.Text;

namespace WarShip.Model
{
    public class Board
    {
        public Cell[,] Cells { get; set; } = new Cell[10, 10];
        public IList<Ship> Ships { get; set; } = new List<Ship>();
    }
}
