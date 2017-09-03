using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingStars
{
    class Player
    {
        public int locationX;
        public int locationY;
        public int oldLocation;   

        public Player(int _x, int _y) //конструктор
        {
            locationX = _x;
            locationY = _y;
            
        }

        public void MoveLeft()
        {
            if (locationX > 5)           // если мы не выходим за границу экрана
            {
                oldLocation = locationX + 4;
                locationX--;            // двигаемся влево
            }
        }

        public void MoveRight()

        {
            if (locationX < 70)         // если мы не выходим за границу экрана
            {
                oldLocation = locationX;
                locationX++;            //двигаемся вправо
            }
        }

        public void DrawPlayer()
        {
            Console.SetCursorPosition(oldLocation, locationY); //мы затираем старую позицию
            Console.Write(" ");
            Console.SetCursorPosition(locationX, locationY); // и рисуем на новых координатах
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("{=^=}");
        }
       
        //public void DrawPlayer1()

        //{
        //    int x1 = locationX - 1;
        //    int x2 = locationX;
        //    int x3 = locationX + 1;
        //    int y1 = locationY + 1;
        //    Console.SetCursorPosition(locationX, locationY);        //ставим в новую координату, пишем красным звезду
        //    Console.Write("X");

        //    Console.SetCursorPosition(x1, y1);        
        //    Console.Write("X");
        //    Console.SetCursorPosition(x2, y1);        
        //    Console.Write("X");
        //    Console.SetCursorPosition(x3, y1);        
        //    Console.Write("X");
           
        //} 

        //у нас должен быть конструктор, который принимает начальные координаты первой точки игрока
        // все остальные точки должны расчитывать свои координаты от этой точки
        // после чего я буду рисовать игрока - ставить курсор в нужные координаты и рисовать символы

    }

}
