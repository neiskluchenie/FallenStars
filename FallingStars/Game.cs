using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;// для таймера

namespace FallingStars
{
    class Game
    {
        public void Intro() //приветствие перед запуском игры. Жмем пробел - игра начинается.
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(30, 10); //мы затираем старую позицию
            Console.WriteLine("||========================================================||");
            Console.SetCursorPosition(30, 11); 
            Console.WriteLine("||--------------------------------------------------------||");
            Console.SetCursorPosition(30, 12); 
            Console.Write("||----------------- ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("УЖАСНОПАДАЮЩИЕ ЗВЕЗДЫ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----------------||");

            Console.SetCursorPosition(30, 13);
            Console.WriteLine("||--------------------------------------------------------||");

            Console.SetCursorPosition(30, 14);
            Console.Write("||------------------- ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("красные и опасные");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ------------------||");

            Console.SetCursorPosition(30, 15);
            Console.WriteLine("||--------------------------------------------------------||");

            Console.SetCursorPosition(30, 16);
            Console.WriteLine("||========================================================||");

            Console.SetCursorPosition(47, 25);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("жми ПРОБЕЛ для продолжения");

            bool introActive = true;                            //интро выполняется пока

            ConsoleKeyInfo key = Console.ReadKey();             // записываем нажатую клавишу в нашу переменную
            
            while (introActive)
            {
                if (key.Key == ConsoleKey.Spacebar)             // Если клавиша был нажат пробел
                {
                    introActive = false;                        //выключаем интро
                    Console.Clear();                            //очищаем консоль
                    GameLoop();                                 //запускаем игру
                }
            }
        }

        public void GameLoop()

        {
            for (int y = 3; y < 42; y++)
            {
                Console.SetCursorPosition(4, y);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write('[');
            }
            for (int y = 3; y < 42; y++)
            {
                Console.SetCursorPosition(75, y);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(']');
            }

            int health = 100;

            Player p = new Player(35, 35);

            List<Star> sList = new List<Star>(); // создаем список объектов наших звездочек
            int starCount = 0;                     //количество звезд на экране, в начале = 0

            Random r = new Random();            //генератор случайного положения звездочек
            Random speed = new Random();        //случайная скорость звездочек
            Random starSpawn = new Random();    //случайная задержка перед появлением каждой звездочки

            Stopwatch spawnTimer = new Stopwatch(); // таймер для задержки перед появлением звездочек
            spawnTimer.Start();
            int elapsedTime = 0;

            bool gameRunning = true; //цикл
            ConsoleKeyInfo userKey; // наша переменная

            while (gameRunning)
            {
                Console.SetCursorPosition(85, 10);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Прочность корпуса: " + health + "%");

                if (starCount < 10)                                     //всего звезд на экране
                {
                    elapsedTime = (int)spawnTimer.ElapsedMilliseconds;  //записываем время со старта
                    int spawn = starSpawn.Next(300, 600);               //задаем случайный интервал
                    if (elapsedTime > spawn)                            // через который будет появляться звездочка
                    {
                        int random = r.Next(5, 75);                     // в случайной координате по х
                        int starSpeed = speed.Next(25, 100);            // и со случайной скоростью

                        Star s = new Star(random, 3, starSpeed);        //создаем звездочку с заданными координатами и скоростью

                        sList.Add(s);                                   //добавляем звездочку в список
                        starCount++;                                    // увеличиваем отслеживаемое количество звезд на экране
                        spawnTimer.Restart();                           //сбрасываем таймер
                    }
                }

                if (Console.KeyAvailable)               // Если клавиша нажата
                {
                    userKey = Console.ReadKey(true);    // мы передаем информацию о нажатой клавише в нашу переменную

                    switch (userKey.Key)                // и в зависимости от того, какая клавиша нажата
                    {
                        case ConsoleKey.LeftArrow:
                            p.MoveLeft();
                            break;

                        case ConsoleKey.RightArrow:
                            p.MoveRight();
                            break;

                        case ConsoleKey.Escape:         // Если жмем выход
                            gameRunning = false;
                            break;
                    }
                }

                for (int lineY = 3; lineY < 42; lineY++)                // проходимся по каждой клеточке нашего игрового поля
                {
                    for (int columnX = 5; columnX < 75; columnX++)
                    {
                        if (columnX == p.locationX && lineY == p.locationY) //и, если координаты совпадают с координатами платформы
                        {
                            p.DrawPlayer();
                        }

                        foreach (Star s in sList)           // для каждой звездочки в нашем списке
                        {
                            if (s.y == 42)                  //а когда звезда достигла края стакана
                            {
                                starCount--;                // мы удаляем ее из отслеживаемых звезд
                            }

                            if (columnX == s.x && lineY == s.y) //если координаты совпадают с координатами нашей звезды
                            {
                                s.Draw(); //мы ее рисуем
                            }

                            if ((s.x == p.locationX || s.x == p.locationX + 1 || s.x == p.locationX + 2 || s.x == p.locationX + 3 || s.x == p.locationX + 4) && s.y == p.locationY) //и, если координаты совпадают с координатами платформы
                            {
                                s.y = 41; // мы перемещаем точку в координаты, в которых она не отображается
                                health -= 10;
                            }
                        }
                    }
                }
                foreach (Star s in sList)
                {
                    s.Move();
                }

            }
        }
    }
}
