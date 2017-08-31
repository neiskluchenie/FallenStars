using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingStars
{
    class Star
    {
        //правой кнопкой мыши по названию проекта - добавить - класс - Star
        // в основном коде
        // Star s1 = new Star(1,2,'*');
        // s1.Draw();
        public int x;
        public int y;
        public char sym;

        public int oldY;

        // в основном коде программы нужно будет сделать переменную типо char star = '*';

        public Star() { }

        public Star(int _x, int _y, char _sym) //конструктор
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public void Move()
        {
            oldY = y;
            y++;
        }

        public void Draw() // все упомянутые символы берутся для конкретного экземпляра класса
        {
            Console.SetCursorPosition(x,oldY);
            Console.Write(" ");
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sym);
        }

       
        // может быть в каждой точке я смогу прописать метод мув, который будет брать координаты конкретно этой точки и изменять их каждый тик таймера.
        // как таймер дотикает, он будет обращаться по очереди к каждой точке на экране и вызывать у них этот метод
    }
}
