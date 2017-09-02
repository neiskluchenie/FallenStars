using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;// для таймера

namespace FallingStars
{
    class Star
    {
                                            // все упомянутые символы берутся для конкретного экземпляра класса
                                            //координаты х,у, и скорость 
        public int x;
        public int y;
        public int starSpeed;

        public bool isActive=true;

        public int oldY;                    // старая у для затирания пустым символом

        Stopwatch sTimer = new Stopwatch(); //таймер и прошедшее время
        int elapsedTime;

        public Star() { }

        public Star(int _x, int _y, int _starSpeed) //конструктор
        {
            x = _x;
            y = _y;
            starSpeed = _starSpeed;
        }

        public void Move()                          //движение звезды
        {
            sTimer.Start();                         //старт таймера
            elapsedTime = (int)sTimer.ElapsedMilliseconds; //записываем прошедшее время в переменную

            if (elapsedTime > starSpeed)            // если времени прошло достаточно
            {
                oldY = y;                           //создаем координату для затирания
                y++;                                //сдвигаем звезду
                sTimer.Restart();                   //перезапускаем таймер
            }
        }

        public void Draw() 
        {
            if (y==39)
            {
                Console.SetCursorPosition(x, y);        //ставим в новую координату, пишем красным звезду
                Console.Write(" ");
                Console.SetCursorPosition(x, oldY);     //ставим в старую координату и затираем
                Console.Write(" ");

                
            }

            else
            {
                Console.SetCursorPosition(x, y);        //ставим в новую координату, пишем красным звезду
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('*');
                Console.SetCursorPosition(x, oldY);     //ставим в старую координату и затираем
                Console.Write(" ");
            }
           
        }
        public void DrawVoid()
        {
            Console.SetCursorPosition(x, y);        //ставим в новую координату, пишем красным звезду
            Console.Write(" ");
            Console.SetCursorPosition(x, oldY);     //ставим в старую координату и затираем
            Console.Write(" ");
        }
    }
}