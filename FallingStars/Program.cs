using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;// для таймера

namespace FallingStars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ужаснопадающие звёзды";
            Console.WindowWidth = 120;
            Console.WindowHeight = 45;
            Console.CursorVisible = false; // скрываем противную мигающую каретку
            
            Game game = new Game();
            game.Intro();
            
        }

    }
}
