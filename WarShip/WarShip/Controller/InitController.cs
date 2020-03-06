using System;
using System.Collections.Generic;
using System.Text;
using WarShip.Model;

namespace WarShip.Controller
{
    public class InitController
    {
        public Game Game { get; set; } = new Game();
        public InitController(Board playerBoard, Board enemyBoard)
        {
            Game.PlayerBoard = playerBoard;
            Game.EnemyBoard = enemyBoard;
        }

        public void AddShip(Coordinate[] coordinates)
        {
            Ship newShip = new Ship
            {
                Length = coordinates.Length,
                Health = coordinates.Length
            };

            newShip.Coordinates = coordinates;

            Game.PlayerBoard.Ships.Add(newShip);
        }

        public void InitCells()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Coordinate coordinate = new Coordinate { X = j, Y = i };
                    Game.PlayerBoard.Cells[i, j] = new Cell
                    {
                        Coord = coordinate,
                        IsShot = false,
                        IsShip = false
                    };
                }
            }

            foreach (var ship in Game.PlayerBoard.Ships)
            {
                foreach (var coord in ship.Coordinates)
                {
                    Game.PlayerBoard.Cells[coord.Y, coord.X].IsShip = true;
                }
            }
        }
    }
}
