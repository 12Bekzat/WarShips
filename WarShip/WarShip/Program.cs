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

            MenuController menuController = new MenuController();

            menuController.ControlMenu();
        }
    }
}
