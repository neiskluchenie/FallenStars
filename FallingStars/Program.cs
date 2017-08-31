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

            Star s1 = new Star(20, 0, '*'); //первый экземпляр класса Стар
            Star s2 = new Star(30, 0, '*');
            Star s3 = new Star(40, 0, '*');
            Star s4 = new Star(50, 0, '*');
            Star s5 = new Star(60, 0, '*');

            List<Star> sList = new List<Star>(); // создаем список объектов наших звездочек

            sList.Add(s1); //добавляем в этот список наши звездочки
            sList.Add(s2);
            sList.Add(s3);
            sList.Add(s4);
            sList.Add(s5);

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
                                oldLocation = locationX + 4;
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
                    foreach (Star s in sList)
                    {
                        s.Move();
                    }
                    
                    timer.Restart();
                }

                for (int lineY = 0; lineY < 40; lineY++)
                {
                    for (int columnX = 0; columnX < 80; columnX++)
                    {
                        //Console.SetCursorPosition(1 + 2 * columnX, lineY);

                        foreach (Star s in sList)
                        {
                            if (columnX == s.x && lineY == s.y)
                            {
                                s.Draw();
                            }

                        }

                        if (columnX == locationX && lineY == locationY)
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
