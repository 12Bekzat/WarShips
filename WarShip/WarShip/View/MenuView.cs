using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarShip.View
{
    public class MenuView
    {
        private List<string> _menuStrings; 
        public int Length { get; }
        public MenuView(string[] strs)
        {
            _menuStrings = strs.ToList();
            Length = _menuStrings.Count;
        }

        public void DrawMenu()
        {
            int i = 1;
            foreach(var str in _menuStrings)
            {
                Console.WriteLine($"{i}. {str}");
                i++;
            }
        }
    }
}
