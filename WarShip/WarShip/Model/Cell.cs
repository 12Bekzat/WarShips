using System;
using System.Collections.Generic;
using System.Text;

namespace WarShip.Model
{
    public class Cell
    {
        public Coordinate Coord { get; set; }
        public bool IsShip { get; set; }
        public bool IsShot { get; set; }
    }
}
