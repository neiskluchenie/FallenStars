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
            bool gameRunning = true; //цикл
            ConsoleKeyInfo userKey; // наша переменная

            int locationX = 10;
            int locationY = 10; // строка нашей платформы
            int oldLocation = 0;

            Console.WindowWidth = 80;
            Console.WindowHeight = 40;

            Console.CursorVisible = false; // скрываем противную мигающую каретку

            int starX = 20;
            int starY = 0;
            int oldStarY = 0;

            int tick = 300;
            int elapsedTime;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (gameRunning)
            {
                // Если клавиша нажата
                if (Console.KeyAvailable)
                {
                    // мы передаем информацию о нажатой клавише в нашу переменную
                    userKey = Console.ReadKey(true);

                    switch (userKey.Key) // и в зависимости от того, какая клавиша нажата
                    {
                        case ConsoleKey.LeftArrow:
                            if (locationX > 0) // если мы не выходим за границу экрана
                            {
                                oldLocation = locationX+4;
                                locationX--; // двигаемся влево
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            if (locationX < 78) // если мы не выходим за границу экрана
                            {
                                oldLocation = locationX;
                                locationX++;  //двигаемся вправо
                            }
                            break;

                        case ConsoleKey.Escape: // Если жмем выход
                            gameRunning = false;
                            break;
                    }
                }
                //таймер
                elapsedTime = (int)timer.ElapsedMilliseconds;
                if (elapsedTime > tick)
                {
                    oldStarY = starY;
                    starY++;
                    timer.Restart();
                }

                for (int lineY = 0; lineY < 40; lineY++)
                {
                    for (int columnX = 0; columnX < 80; columnX++)
                    {
                        //Console.SetCursorPosition(1 + 2 * columnX, lineY);

                        if (columnX == starX && lineY == starY)
                        {
                            Console.SetCursorPosition(starX, oldStarY);
                            Console.Write(" ");
                            Console.SetCursorPosition(starX, starY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("*");
                        }

                        else if (columnX == locationX && lineY == locationY)
                        {
                            Console.SetCursorPosition(oldLocation, locationY);
                            Console.Write(" ");
                            Console.SetCursorPosition(locationX, locationY);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("#####");
                        }

                    }
                }

            }

        }



    }
}
