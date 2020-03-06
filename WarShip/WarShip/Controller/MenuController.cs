using System;
using System.Collections.Generic;
using System.Text;
using WarShip.Controller;
using WarShip.Model;

namespace WarShip.View
{
    public class MenuController
    {
        public bool Menu()
        {
            while (true)
            {
                Console.WriteLine("1.Play");
                Console.WriteLine("2.Exit");
                Console.Write("Input: ");
                if (int.TryParse(Console.ReadLine(), out var key))
                {
                    switch (key)
                    {
                        case 1:
                            GameView gameView = new GameView();
                            gameView.DrawBoard(4, 5);
                            GameController controller = new GameController(new Board(), new Board());


                            while (true)
                            {
                                Console.SetCursorPosition(0, Console.WindowHeight - 4);
                                Console.WriteLine("Введите координаты: ");
                                if (int.TryParse(Console.ReadLine(), out var x) && int.TryParse(Console.ReadLine(), out var y))
                                {
                                    gameView.EnemyBoard.DrawShoot(controller.Shoot(new Coordinate { X = x, Y = y }, controller._initController.Game.EnemyBoard), new Coordinate { X = x, Y = y });
                                }
                            }
                            break;
                        case 2:
                            return true;
                            break;
                    }
                }
            }
        }

        public void SetFleet()
        {

        }
    }
}
