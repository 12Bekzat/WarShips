using System;
using System.Collections.Generic;
using System.Text;

namespace WarShip.Model
{
    public class Ship
    {
        public int Length { get; set; } 
        public int Health { get; set; } 
        public Coordinate[] Coordinates { get; set; }
    }
}
