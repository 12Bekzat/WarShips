﻿namespace WarShip.Model
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate()
        {

        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}