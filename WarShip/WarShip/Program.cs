using System;
using WarShip.Controller;
using WarShip.Model;
using WarShip.View;

namespace WarShip
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.ReadLine();
        }
    }
}
