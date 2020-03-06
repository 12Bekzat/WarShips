using System;
using System.Collections.Generic;
using System.Text;

namespace WarShip.View
{
    public class GameView
    {
        public BoardView PlayerBoard { get; set; } = new BoardView();
        public BoardView EnemyBoard { get; set; } = new BoardView();
        public void DrawBoard(int xSt, int ySt)
        {
            Console.SetCursorPosition(xSt, ySt - 2);
            Console.WriteLine(" Игрок:");
            PlayerBoard.DrawBoard(xSt, ySt);

            Console.SetCursorPosition(xSt + 15, ySt - 2);
            Console.WriteLine("Противник:");
            EnemyBoard.DrawBoard(xSt + 17, ySt);
        }
    }
}
