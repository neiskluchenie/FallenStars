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
            int locationY = 35; // строка нашей платформы
            int oldLocation = 0;

            Console.WindowWidth = 80;
            Console.WindowHeight = 40;

            Console.CursorVisible = false; // скрываем противную мигающую каретку

            int basicX = 0;

            List<Star> sList = new List<Star>(); // создаем список объектов наших звездочек
            Random r = new Random(); //генератор случайного положения звездочек
            Random speed = new Random();

            for (int p = 0; p < 10; p++) //несколько раз
            {
               
                int random = r.Next(6, 10);

                int starSpeed = speed.Next(200, 600);

                Star s = new Star(basicX, 0, '*',starSpeed); //создаем звездочку с заданными координатами
                basicX += random; //меняем координату
                sList.Add(s); //добавляем звездочку в список
            }

            
            

            //foreach (Star s in sList)
            //{
            //    s.Move();
            //}
            //int tick = 300;
            //int elapsedTime;

            //Stopwatch timer = new Stopwatch();
            //timer.Start();

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
                //elapsedTime = (int)timer.ElapsedMilliseconds;
                //if (elapsedTime > tick)
                //{
                //    foreach (Star s in sList)
                //    {
                //        s.Move();
                //    }

                //    timer.Restart();
                //}
                foreach (Star s in sList)
                {
                    s.Move();
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
