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
        public int x;
        public int y;
        public char sym;
        public int starSpeed;

        public int oldY;

        int tick = 300;
        int elapsedTime;

        Stopwatch sTimer = new Stopwatch();

        Random s = new Random();

        public Star() { }

        public Star(int _x, int _y, char _sym, int _starSpeed) //конструктор
        {
            x = _x;
            y = _y;
            sym = _sym;
            starSpeed = _starSpeed;
        }

        public void Move()
        {
            sTimer.Start();
            //int random = s.Next(200, 600);
            //while (true)
            //{
                elapsedTime = (int)sTimer.ElapsedMilliseconds;

                if (elapsedTime > starSpeed)
                {
                    oldY = y;
                    y++;
                    sTimer.Restart();
                }

                //oldY = y;
                //y++;
            //}
        }

        public void Draw() // все упомянутые символы берутся для конкретного экземпляра класса
        {
            Console.SetCursorPosition(x, oldY);
            Console.Write(" ");
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sym);
        }


        // может быть в каждой точке я смогу прописать метод мув, который будет брать координаты конкретно этой точки и изменять их каждый тик таймера.
        // как таймер дотикает, он будет обращаться по очереди к каждой точке на экране и вызывать у них этот метод

    }
}