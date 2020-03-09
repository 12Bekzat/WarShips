using System;
using System.Collections.Generic;
using System.Text;
using WarShip.Model;
using WarShip.View;

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

        public void PlaceShips(int xSt, int ySt)
        {
            BoardView boardView = new BoardView(xSt, ySt);
            boardView.DrawBoard(xSt, ySt);

            int length = 2;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    int deckQty;
                    Coordinate upperLeft = new Coordinate();
                    bool isHorizontal = true;
                    String isHorizontalStr;
                    Ship ship = new Ship();
                    ship.Coordinates = new Coordinate[i + 1];
                    ship.Health = i + 1;
                    ship.Length = i + 1;
                    do
                    {
                        bool error;
                        deckQty = i + 1;
                        if (i > 0)
                        {
                            do
                            {
                                error = false;
                                Console.Write("Задайте ориентацию " + (j + 1) + "-го " + deckQty + "-палубного корабля(h - горизонтальная, v - вертикальная): ");
                                isHorizontalStr = Console.ReadLine();
                                if (isHorizontalStr == "h") isHorizontal = true;
                                else if (isHorizontalStr == "v") isHorizontal = false;
                                else error = true;
                                if (error) Console.WriteLine("Неверный символ! Повторите ввод.");
                            } while (error);
                        }

                        do
                        {
                            error = false;
                            Console.Write("Введите координату верхней или левой палубы " + (j + 1) + "-го " + deckQty + "-палубного корабля: ");
                            if (!int.TryParse(Console.ReadLine(), out var x))
                                error = true;
                            if (!int.TryParse(Console.ReadLine(), out var y))
                                error = true;
                            if (upperLeft.X < 0 || upperLeft.X > 9 || upperLeft.Y < 0 || upperLeft.Y > 9) error = true;

                            if (!error)
                            {
                                upperLeft = new Coordinate(x, y);
                                boardView.DrawShoot(true, upperLeft);
                            }
                            if (error) Console.Write("Ошибка! Попробуйте еще раз.");
                        } while (error);
                        if (!CheckFreeSpace(upperLeft.X, upperLeft.Y, deckQty, isHorizontal, Game.PlayerBoard))
                            Console.Write("Здесь нельзя располагать корабль. Попробуйте еще раз.");

                    } while (!CheckFreeSpace(upperLeft.X, upperLeft.Y, deckQty, isHorizontal, Game.PlayerBoard));
                    for (int s = 0; s < deckQty; s++)
                    {
                        if (isHorizontal)
                            ship.Coordinates[s] = new Coordinate(upperLeft.X + s, upperLeft.Y);
                        else
                            ship.Coordinates[s] = new Coordinate(upperLeft.X, upperLeft.Y + s);
                    }
                    MadeShipArea(ship);
                    Game.PlayerBoard.Ships.Add(ship);
                }
                length--;
            }
        }

        public bool CheckFreeSpace(int x, int y, int shipLength, bool isHorizontal, Board field)
        {
            if (isHorizontal && (x + shipLength) > 9) return false;
            if (!isHorizontal && (y + shipLength) > 9) return false;
            for (int i = 0; i < shipLength; i++)
            {
                if (isHorizontal)
                    x += i;
                else
                    y += i;

                for (int j = x - 1; j < x + 2; j++)
                {
                    for (int k = y - 1; k < y + 2; k++)
                    {
                        if (j < 0 || k < 0 || j > 9 || k > 9) continue;
                        if (field.Cells[k, j].IsShipArea) return false;
                    }
                }
            }
            return true;
        }

        public void MadeShipArea(Ship ship)
        {
            foreach (var coordinate in ship.Coordinates)
            {
                Game.PlayerBoard.Cells[coordinate.Y, coordinate.X].IsShip = true;
                for (int j = coordinate.X - 1; j < coordinate.X + 2; j++)
                {
                    for (int k = coordinate.Y - 1; k < coordinate.Y + 2; k++)
                    {
                        if (j < 0 || k < 0 || j > 9 || k > 9) continue;
                        Game.PlayerBoard.Cells[k, j].IsShipArea = true;
                    }
                }
            }
        }
    }
}
