using System;
using System.Collections.Generic;
using System.Text;
using WarShip.Model;

namespace WarShip.Controller
{
    public class GameController
    {
        public InitController _initController { get; }
        public GameController(Board playerBoard, Board enemyBoard)
        {
            _initController = new InitController(playerBoard, enemyBoard);
            _initController.AddShip(new Coordinate[]
            { new Coordinate
            {
                X = 3,
                Y = 3,
            },
            new Coordinate
            {
                X = 3,
                Y = 4
            }
            });

            _initController.AddShip(new Coordinate[]
            { new Coordinate
            {
                X = 0,
                Y = 0,
            },
            new Coordinate
            {
                X = 0,
                Y = 1
            }
            });

            _initController.AddShip(new Coordinate[]
            { new Coordinate
            {
                X = 9,
                Y = 9,
            },
            new Coordinate
            {
                X = 8,
                Y = 9
            }
            });
            _initController.InitCells();
        }

        public bool Shoot(Coordinate coordinate, Board board)
        {
            board.Cells[coordinate.Y, coordinate.X].IsShot = true;
            return board.Cells[coordinate.Y, coordinate.X].IsShip;
        }
    }
}
