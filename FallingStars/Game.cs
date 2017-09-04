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
                    GameField();
                    GameLoop();                                 //запускаем игру
                }
                else
                {
                    key = Console.ReadKey();
                }
            }
        }

        public void GameField() // рисуем границы игрового поля
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
        }

        public void GameOver() //приветствие перед запуском игры. Жмем пробел - игра начинается.
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(30, 10); 
            Console.WriteLine("||========================================================||");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("||--------------------------------------------------------||");
            Console.SetCursorPosition(30, 12);
            Console.Write("||----------- ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Твой прекрасный корабль сломан :( ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ---------||");

            Console.SetCursorPosition(30, 13);
            Console.WriteLine("||--------------------------------------------------------||");

            Console.SetCursorPosition(45, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("жми ПРОБЕЛ чтобы получить новый");

            bool introActive = true;                            //интро выполняется пока

            ConsoleKeyInfo key = Console.ReadKey();             // записываем нажатую клавишу в нашу переменную

            while (introActive)
            {
                if (key.Key == ConsoleKey.Spacebar)             // Если клавиша был нажат пробел
                {
                    introActive = false;                        //выключаем интро
                    Console.Clear();                            //очищаем консоль
                    GameField();
                    GameLoop();                                 //запускаем игру
                }
                else
                {
                    key = Console.ReadKey();
                }
            }
        }

        public void Win() //приветствие перед запуском игры. Жмем пробел - игра начинается.
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(30, 10); //мы затираем старую позицию
            Console.WriteLine("||========================================================||");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("||--------------------------------------------------------||");
            Console.SetCursorPosition(30, 12);
            Console.Write("||---------------- ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("МОИ ПОЗДРАВЛЕНИЯ, ПИЛОТ!");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" --------------||");

            Console.SetCursorPosition(30, 13);
            Console.WriteLine("||--------------------------------------------------------||");

            Console.SetCursorPosition(30, 14);
            Console.Write("||----------------- ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("корабль в безопасности");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ---------------||");

            Console.SetCursorPosition(30, 15);
            Console.WriteLine("||--------------------------------------------------------||");

            Console.SetCursorPosition(30, 16);
            Console.WriteLine("||========================================================||");

            Console.SetCursorPosition(45, 25);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("жми ПРОБЕЛ для следующего рейса");

            bool introActive = true;                            //интро выполняется пока

            ConsoleKeyInfo key = Console.ReadKey();             // записываем нажатую клавишу в нашу переменную

            while (introActive)
            {
                if (key.Key == ConsoleKey.Spacebar)             // Если клавиша был нажат пробел
                {
                    introActive = false;                        //выключаем интро
                    Console.Clear();                            //очищаем консоль
                    GameField();
                    GameLoop();                                 //запускаем игру
                }
                else
                {
                    key = Console.ReadKey();
                }
            }
        }

        int fallenStars = 0; //считаем успешно пройденные звезды
        int acceleration = 250; //задержка перед перемещением игрока
        int spawnMin = 500;
        int spawnMax = 1000;

        public void GameLoop()
        {
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

            Stopwatch sTimer = new Stopwatch(); //таймер и прошедшее время
            int elapsedTime1;
            sTimer.Start();                         //старт таймера

            while (gameRunning)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(85, 10);
                Console.Write("Прочность корпуса: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(health);

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(85, 12);
                Console.Write("Упавшие звезды: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(fallenStars);

                //Console.SetCursorPosition(85, 14);
                //Console.Write("Ускорение " + acceleration);

                if (starCount < 25)                                     //всего звезд на экране
                {
                    elapsedTime = (int)spawnTimer.ElapsedMilliseconds;  //записываем время со старта
                    int spawn = starSpawn.Next(spawnMin, spawnMax);               //задаем случайный интервал
                    if (elapsedTime > spawn)                            // через который будет появляться звездочка
                    {
                        int random = r.Next(5, 75);                     // в случайной координате по х
                        //int starSpeed = speed.Next(25, 100);            // и со случайной скоростью

                        Star s = new Star(random, 3);        //создаем звездочку с заданными координатами и скоростью

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

                for (int lineY = 3; lineY < 43; lineY++)                // проходимся по каждой клеточке нашего игрового поля
                {
                    for (int columnX = 5; columnX < 75; columnX++)
                    {
                        if (columnX == p.locationX && lineY == p.locationY) //и, если координаты совпадают с координатами платформы
                        {
                            p.DrawPlayer();
                        }

                        foreach (Star s in sList)           // для каждой звездочки в нашем списке
                        {
                            if (columnX == s.x && lineY == s.y) //если координаты совпадают с координатами нашей звезды
                            {
                                s.Draw(); //мы ее рисуем
                            }

                            if (s.y == 41)                  //а когда звезда достигла края стакана
                            {
                                s.y = 42;
                                starCount--;                // мы удаляем ее из отслеживаемых звезд
                                fallenStars++;
                            }

                            if ((s.x == p.locationX || s.x == p.locationX + 1 || s.x == p.locationX + 2 || s.x == p.locationX + 3 || s.x == p.locationX + 4) && s.y == p.locationY) //и, если координаты совпадают с координатами платформы
                            {
                                s.y = 42; // мы перемещаем точку в координаты, в которых она не отображается
                                starCount--;
                                health -= 10;
                            }
                        }
                    }
                }

                elapsedTime1 = (int)sTimer.ElapsedMilliseconds; //записываем прошедшее время в переменную

                if (elapsedTime1 > acceleration)            // если времени прошло достаточно
                {
                    foreach (Star s in sList)
                    {
                        s.Move();
                    }
                    sTimer.Restart();
                }


                if (fallenStars>=10)
                {
                    acceleration = 200;
                    spawnMin = 450;
                    spawnMax = 900;
                }
                if (fallenStars >=50)
                {
                    acceleration = 150;
                    spawnMin = 350;
                    spawnMax = 700;
                }
                if (fallenStars >= 100)
                {
                    acceleration = 125;
                    spawnMin = 250;
                    spawnMax = 500;
                }
                if (fallenStars >= 200)
                {
                    acceleration = 100;
                    spawnMin = 150;
                    spawnMax = 300;
                }
                if (fallenStars >= 300)
                {
                    acceleration = 75;
                    spawnMin = 125;
                    spawnMax = 250;
                }
                if (fallenStars >= 500)
                {
                    acceleration = 50;
                    spawnMin = 100;
                    spawnMax = 200;
                }
                if (fallenStars >= 750)
                {
                    acceleration = 25;
                    spawnMin = 75;
                    spawnMax = 150;
                }
                if (fallenStars == 1000)
                {
                    gameRunning = false;
                    fallenStars = 0; //считаем успешно пройденные звезды
                    acceleration = 250; //задержка перед перемещением игрока
                    spawnMin = 500;
                    spawnMax = 1000;
                    Console.Clear();
                    Win();
                }

                if (health==90)
                {
                    Console.SetCursorPosition(106, 10);
                    Console.Write(" ");
                }
                if (health==0)
                {
                    gameRunning = false;
                    fallenStars = 0; //считаем успешно пройденные звезды
                    acceleration = 250; //задержка перед перемещением игрока
                    spawnMin = 500;
                    spawnMax = 1000;
                    Console.Clear();
                    GameOver();
                    
                }
            }
        }
    }
}
