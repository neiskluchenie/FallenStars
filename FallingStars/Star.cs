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
                                            //координаты х,у
        public int x;
        public int y;
               
        public int oldY;                    // старая у для затирания пустым символом

        public Star() { }

        public Star(int _x, int _y) //конструктор
        {
            x = _x;
            y = _y;
        }

        public void Move()                          //движение звезды
        {
                oldY = y;                           //создаем координату для затирания
                y++;                                //сдвигаем звезду
        }

        public void Draw() 
        {
            if (y==42)
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
    }
}