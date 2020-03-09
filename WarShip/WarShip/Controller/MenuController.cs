using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarShip.Controller;
using WarShip.Model;

namespace WarShip.View
{
    public class MenuController
    {
        private MenuView _menuView;

        public MenuController()
        {
            _menuView = new MenuView(new string[] { "Play", "Exit" });
        }



        private void Play(GameController controller)
        {
            GameView gameView = new GameView();
            gameView.DrawBoard(4, 5);


            while (true)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 4);
                Console.WriteLine("Введите координаты: ");
                if (int.TryParse(Console.ReadLine(), out var x) && int.TryParse(Console.ReadLine(), out var y))
                {
                    bool isHit = controller.Shoot(new Coordinate { X = x, Y = y }, controller._initController.Game.PlayerBoard);

                    if (isHit)
                    {
                        foreach (var ship in controller._initController.Game.PlayerBoard.Ships)
                        {
                            foreach (var coord in ship.Coordinates)
                            {
                                if (coord.X ==  x && coord.Y == y )
                                {
                                    ship.Health--;
                                    if (ship.Health <= 0)
                                    {
                                        controller.ShipDestroyed(ship, ref gameView);
                                        if (controller._initController.Game.PlayerBoard.Ships.Where(x => x.Health <= 0).Count() == controller._initController.Game.PlayerBoard.Ships.Count)
                                        {
                                            ControlMenu();
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    gameView.PlayerBoard.DrawShoot(isHit, new Coordinate { X = x, Y = y });
                }
            }
        }

        public void ControlMenu()
        {
            _menuView.DrawMenu();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var chooise))
                {
                    if (chooise > 0 || chooise <= _menuView.Length)
                    {
                        if (chooise == 1)
                        {
                            GameController game = new GameController(new Board(), new Board());
                            game.PlaceShips(5, 4);

                            Console.Clear();

                            Play(game);
                        }
                        else if (chooise == 2)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
