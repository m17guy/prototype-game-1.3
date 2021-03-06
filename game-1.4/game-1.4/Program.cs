﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace game_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<room> maze = new List<room>();
            player guy = new player();
            room MyRoom = new room(RoomSeed(), guy, false);
            Thread.Sleep(20);
            while (true)
            {
                Console.Clear();
                MyRoom.PrintRoom();
                try
                {
                    move(MyRoom, guy);
                }
                catch(Exception e)
                {
                    //maze.Add(MyRoom);
                    if (e.Message == "Index was outside the bounds of the array.")
                        MyRoom = NextRoom(guy);
                    else
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
            }


        }
        static string RoomSeed()
        {
            Random r = new Random();
            switch (r.Next(3))
            {
                case (1):
                    return "long";
                case (2):
                    return "high";
                default:
                    return "not a room";
            }
        }
        static void move(room entrince, player guy)
        {
            ConsoleKeyInfo action = Console.ReadKey();
            switch (action.Key)
            {
                case (ConsoleKey.UpArrow):
                    entrince.MoveChar(guy.ylocation - 1, guy.xlocation, guy, false);
                    break;
                case (ConsoleKey.LeftArrow):
                    entrince.MoveChar(guy.ylocation, guy.xlocation - 1, guy, false);
                    break;
                case (ConsoleKey.DownArrow):
                    entrince.MoveChar(guy.ylocation + 1, guy.xlocation, guy, false);
                    break;
                case (ConsoleKey.RightArrow):
                    entrince.MoveChar(guy.ylocation, guy.xlocation + 1, guy, false);
                    break;
                default:
                    break;
            }
        }
        static room NextRoom(player p)
        {
            room r = new room(RoomSeed(), p, true);
            if (p.ylocation == 0)
            {
                //r.MoveChar(r.hight - 1, r.width - rand.Next(2, r.width - 1), p);
            }
            return r;
                
        }
    }
}
