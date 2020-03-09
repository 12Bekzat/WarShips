using System;
using System.Collections.Generic;
using System.Text;
using WarShip.Model;

namespace WarShip.View
{
    public class BoardView
    {
        private int startX;
        private int startY;
        private const int SIZE = 10;

        public BoardView()
        {

        }

        public BoardView(int xSt, int ySt)
        {
            startX = xSt;
            startY = ySt;
        }

        public void DrawBoard(int xSt, int ySt)
        {
            startX = xSt;
            startY = ySt;

            for (int i = 0; i < SIZE; i++)
            {
                Console.SetCursorPosition(xSt + 1 + i, ySt);
                Console.Write(i);
            }

            for (int i = 0; i < SIZE; i++)
            {
                Console.SetCursorPosition(xSt, ySt + 1 + i);
                Console.Write(i);
                for(int j = 0; j < SIZE; j++)
                {
                    Console.Write(CellView.Sea);
                }
            }
        }

        public void DrawShoot(bool isShip, Coordinate coordinate)
        {
            Console.SetCursorPosition(coordinate.X + startX + 1, coordinate.Y + startY + 1);
            if(isShip)
                Console.WriteLine(CellView.Hit);
            else if(isShip == false)
                Console.WriteLine(CellView.Miss);
            Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 1);
                Console.WriteLine("destroy");
        }
    }
}
