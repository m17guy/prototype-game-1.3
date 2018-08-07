using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1._3
{
    class Room
    {
        public double location;
        public bool potion = false;
        public bool weaponSword = false;
        public bool weaponStaff = false;
        public bool weaponBow = false;
        public string d;
        public void getWepon(Player me, int couse)
        {
            switch (couse)
            {
                case 1:
                    switch(me.job)
                    {
                        case 2:
                            Console.WriteLine("you drop your bow");
                            weaponBow = true;
                            break;
                        case 3:
                            Console.WriteLine("you drop your staff");
                            weaponStaff = true;
                            break;
                    }
                    Console.WriteLine("you then pick up the sword, it feels natural in your hands");
                    weaponSword = false;
                    me.job = couse;
                    break;
                case 2:
                    switch (me.job)
                    {
                        case 1:
                            Console.WriteLine("you drop your sword");
                            weaponSword = true;
                            break;
                        case 3:
                            Console.WriteLine("you drop your staff");
                            weaponStaff = true;
                            break;
                    }
                    Console.WriteLine("you then pick up the bow, it feels natural in your hands");
                    weaponBow = false;
                    me.job = couse;
                    break;
                case 3:
                    switch (me.job)
                    {
                        case 2:
                            Console.WriteLine("you drop your bow");
                            weaponBow = true;
                            break;
                        case 1:
                            Console.WriteLine("you drop your sword");
                            weaponSword = true;
                            break;
                    }
                    Console.WriteLine("you then pick up the staff, it feels natural in your hands");
                    weaponStaff = false;
                    me.job = couse;
                    break;


            }
        }
        public void discription(Player me)
        {
            switch (location)
            {
                case (-1.1):
                    {
                        Console.WriteLine("You find yourself on a pile rubble. Your head hurts as if you've hit it,");
                        Console.WriteLine("you can't quite remember where you are or why.");
                        Console.WriteLine("on the north wall of this room is a door, to its right in the corner is a sword.");
                        break;
                    }
                case (1):
                    {
                        Console.WriteLine("As you cross the doors threshold you see a skeleton shambling across");
                        Console.WriteLine("the room you enterd. He is walking so slowly you let yourself look around the");
                        Console.WriteLine("room, it's so sparse you have nothing to do here but attack him.");
                        Console.WriteLine("there is a door to the north, south and west");
                        break;
                    }
                case (1.1):
                    {
                        Console.WriteLine("This room is so crowded with rubble you can barely see the floor.");
                        Console.WriteLine("The east wall looks as if it were a loose collection of debris seeming");
                        Console.WriteLine("to be held up by a sort of magic,");
                        Console.WriteLine("you know this is the case because the whole wall is glowing a vibrant blue");
                        if (me.job == 3)
                        {
                            Console.WriteLine("you do not have a spell to stop it");
                        }
                        Console.WriteLine("one of the piles on the floor seems to have something red underneath it");
                        //Console.WriteLine("it's a closed bottle, you recognize it as a health potion");     to be implomented
                        Console.WriteLine("there is a door to the south");
                        break;
                    }
                case (0):
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    }
                case (0.1):
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    }
                case (0.2):
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    }
                case (0.3):
                    {
                        Console.WriteLine();
                        break;
                    }
                case (1.3):
                    {
                        Console.WriteLine();
                        break;
                    }
                case (2.3):
                    {
                        Console.WriteLine();
                        break;
                    }
                case (2.2):
                    {
                        Console.WriteLine();
                        break;
                    }
            }
        }
    }
}
