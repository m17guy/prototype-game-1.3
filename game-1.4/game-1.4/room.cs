using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace game_1._4
{
    class room
    {
        public int hight { get; set; }
        public int width { get; set; }
        item Key;
        char[,] reprezentation;
        public room(string seed, player guy)
        {
            Random ysize = new Random();
            Random xsize = new Random();
            switch (seed) //room type
            {
                case ("high"):
                    hight = ysize.Next(18, 22);
                    width = xsize.Next(11, 19);
                    break;
                case ("long"):
                    hight = ysize.Next(7, 12);
                    width = xsize.Next(45, 59);
                    break;
                default:
                    hight = ysize.Next(13, 19);
                    width = xsize.Next(25, 32);
                    break;

            }
            GenerateRoom();
            Random StartLocation = new Random();
            MoveChar(hight - StartLocation.Next(2, hight - 1), width - StartLocation.Next(2, width - 1), guy);
            Thread.Sleep(30);
            Key = new item { ylocation = hight - ysize.Next(2, hight - 1), xlocation = width - xsize.Next(2, width - 1), rep = '^' };
            MoveChar(Key);
        }
        void GenerateRoom()
        {
            reprezentation = new char[hight, width];
            for (int x = 0; x < width; x++)
            {
                reprezentation[0, x] = '*';
            }
            for (int i = 1; i < hight-1; i++)
            {
                reprezentation[i, 0] = '*';
                for (int x = 1; x < width - 1; x++)
                {
                    reprezentation[i, x] = '-';
                }
                reprezentation[i, width-1] = '*';
            }
            for (int x = 0; x < width; x++)
            {
                reprezentation[hight - 1, x] = '*';
            }

        }
        public void PrintRoom()
        {
            for(int y = 0; y < hight; y++)
            {
                for(int x = 0; x < width-1; x++)
                {
                    if (reprezentation[y, x] == '@')
                        Console.ForegroundColor = ConsoleColor.Blue;
                    if (reprezentation[y, x] == '^')
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(reprezentation[y, x]);
                    Console.ResetColor();
                }
                Console.WriteLine(reprezentation[y, width-1]);
            }
        }
        public void MoveChar(int y,int x,player p)
        {
            if (reprezentation[y, x] != '*')
            {
                if (reprezentation[y, x] == '^')
                {
                    MakeDoor(1, 1);
                }
                reprezentation[p.ylocation, p.xlocation] = '-';//makes small bug, the next line is there to fix it
                //reprezentation[0, 0] = '*';
                reprezentation[y, x] = p.rep;
                p.ylocation = y;
                p.xlocation = x;
            }
        }
        public void MoveChar(item i)
        {
            reprezentation[i.ylocation, i.xlocation] = i.rep;
        }
        public void MoveChar(int y, int x, char c)
        {
            reprezentation[y, x] = c;
        }
        public void MakeDoor(int lastdoorY, int lastdoorX)
        {
            int yline = 0, xline = 1;
            char DoorRep = '-';
            Random doorloction = new Random();
            switch (doorloction.Next(5))
            {
                case (1)://top line
                    yline = 0;
                    xline = doorloction.Next(1, width - 1);
                    break;
                case (2)://botom line
                    yline = hight-1;
                    xline = doorloction.Next(1, width - 1);
                    break;
                case (3)://left line
                    xline = 0;
                    yline = doorloction.Next(1, hight - 1);
                    DoorRep = '|';
                    break;
                case (4)://right line
                    xline = width - 1;
                    yline = doorloction.Next(1, hight - 1);
                    DoorRep = '|';
                    break;
            }
            MoveChar(yline, xline, DoorRep);
        }
        

    }
}
