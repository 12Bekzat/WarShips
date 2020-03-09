using System;
using System.Collections.Generic;
using System.Text;
using WarShip.Model;
using WarShip.View;

namespace WarShip.Controller
{
    public class GameController
    {
        public InitController _initController { get; }
        public GameController(Board playerBoard, Board enemyBoard)
        {
            _initController = new InitController(playerBoard, enemyBoard);
            _initController.InitCells();
        }

        public bool Shoot(Coordinate coordinate, Board board)
        {
            board.Cells[coordinate.Y, coordinate.X].IsShot = true;
            return board.Cells[coordinate.Y, coordinate.X].IsShip;
        }

        public void PlaceShips(int xSt, int ySt)
        {
            _initController.PlaceShips(xSt, ySt);
        }

        public void ShipDestroyed(Ship ship, ref GameView gameView)
        {
            foreach (var coordinate in ship.Coordinates)
            {
                for (int j = coordinate.X - 1; j < coordinate.X + 2; j++)
                {
                    for (int k = coordinate.Y - 1; k < coordinate.Y + 2; k++)
                    {
                        if (j < 0 || k < 0 || j > 9 || k > 9) continue;
                        _initController.Game.PlayerBoard.Cells[k, j].IsShot = true;
                        gameView.PlayerBoard.DrawShoot(_initController.Game.PlayerBoard.Cells[k, j].IsShip, new Coordinate { X = j, Y = k });
                    }
                }
            }
        }
    }
}
