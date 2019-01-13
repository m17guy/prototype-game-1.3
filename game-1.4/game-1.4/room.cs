using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace game_1._4
{
    class room
    {
        public char SideDoor = '0';
        static public int RoomNumber = 0;
        public int ThisRoomNumber;
        public int hight { get; set; }
        public int width { get; set; }
        item Key;
        public int LastDoor;
        char[,] reprezentation;
        public room(string seed, player guy, bool NewRoom)
        {
            ThisRoomNumber = RoomNumber++;
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
            if (NewRoom) //door was 1-top 2-botom 3-left 4-right
            {
                if (guy.ylocation == 0)
                {
                    LastDoor = 1;
                    SideDoor = '1';
                }
                if (guy.xlocation == 0)
                {
                    LastDoor = 3;
                    SideDoor = '3';
                }

                MakeDoor(LastDoor, true);
            }
            Random StartLocation = new Random();
            MoveChar(hight - StartLocation.Next(2, hight - 1), width - StartLocation.Next(2, width - 1), guy, NewRoom);
            Thread.Sleep(30);
            Key = new item { ylocation = hight - ysize.Next(2, hight - 1), xlocation = width - xsize.Next(2, width - 1), rep = '^' };
            while(Key.ylocation==guy.ylocation || Key.xlocation == guy.xlocation)
            {
                Key = new item { ylocation = hight - ysize.Next(2, hight - 1), xlocation = width - xsize.Next(2, width - 1), rep = '^' };
            }
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
        public void MoveChar(int y,int x,player p, bool NewRoom)
        {
            if (reprezentation[y, x] != '*' || NewRoom)
            {
                if (reprezentation[y, x] == '^')
                {
                    MakeDoor((int)char.GetNumericValue(SideDoor),false);
                }
                try
                {
                    char temp = SideDoor;
                    if (reprezentation[y, x] == '|')
                        SideDoor = '|';
                    if (SideDoor == '|')
                    {
                        reprezentation[p.ylocation, p.xlocation] = '|';
                        SideDoor = temp;
                    }
                    else
                        reprezentation[p.ylocation, p.xlocation] = '-';
                }
                catch
                {

                }
                reprezentation[0, 0] = '*';//makes small bug, is there to fix it
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
        public void MakeDoor(int lastdoor ,bool olddoor)
        {
            int yline = 0, xline = 1;
            char DoorRep = '-';
            Random doorloction = new Random();
            if (olddoor)
            {

            }
            else
            {

                switch (doorloction.Next(5))
                {
                    case (1)://top line
                        yline = 0;
                        xline = doorloction.Next(1, width - 1);
                        break;
                    case (2)://botom line
                        yline = hight - 1;
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
            }
            MoveChar(yline, xline, DoorRep);
        }

    }
}
