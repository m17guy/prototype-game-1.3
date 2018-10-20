using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1._3
{
    class Room
    {
        public Monster Mhere;
        public bool IsMonster;
        public bool potion;
        public bool weaponSword;
        public bool weaponStaff;
        public bool weaponBow;
        public bool doorNorth;
        public bool doorEast;
        public bool doorSouth;
        public bool doorWest;
        public double location;
        public void getWepon(Player me, int choice)
        {
            switch (choice)
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
                    Console.WriteLine("you pick up the sword, it feels natural in your hands");
                    weaponSword = false;
                    me.job = choice;
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
                    me.job = choice;
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
                    Console.WriteLine("you pick up the staff, it feels natural in your hands");
                    weaponStaff = false;
                    me.job = choice;
                    break;


            }
        }
        public void discription(Player me) //(x,y)
        {
            //the player parameter if for diferent jobs
            switch (location)
            {
                case (-1.1):
                        Console.WriteLine("You find yourself on a pile rubble. Your head hurts as if it's been hit");
                        Console.WriteLine("you can't quite remember where you are or why.");
                        Console.WriteLine("in separate corners of the room are a sword, a bow and a staff.");
                        weaponBow = true; weaponStaff = true; weaponSword = true;
                        doorNorth = true;
                        break;
                case (1):
                        Console.WriteLine("As you cross the doors threshold you see a skeleton shambling across");
                        Console.WriteLine("the room you enterd. He is walking so slowly you let yourself look around the");
                        Console.WriteLine("room, it's so sparse you have nothing to do here but attack him.");
                        doorNorth = true; doorWest = true; doorSouth = true; //monster = true;
                    break;
                case (1.1):
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
                    doorSouth = true;
                    break;
                case (0):
                        Console.WriteLine("room 0");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        doorNorth = true; doorEast = true;
                        break;
                case (0.1):
                        Console.WriteLine("room 0.1");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        doorNorth = true; doorSouth = true;
                    break;
                case (0.2):
                        Console.WriteLine("room 0.2");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        doorNorth = true; doorSouth = true;
                    break;
                case (0.3):
                        Console.WriteLine("room 0.3");
                        doorEast = true; doorSouth = true;
                        break;
                case (1.3):
                        Console.WriteLine("room 1.3");
                        doorEast = true; doorWest = true;
                        break;
                case (2.3):
                        Console.WriteLine("room 2.3");
                        doorNorth = true; doorSouth = true; doorWest = true;
                        break;
                case (2.2):
                        Console.WriteLine("room 2.2");
                        doorEast = true; doorNorth = true;
                        break;
                case 2.4:
                    Console.WriteLine("room 2.4");
                    doorSouth = true;
                    break;
                case 2.1:
                    Console.WriteLine("room 2.1");
                    doorWest = true;
                    break;
            }
        }
        public void doors()
        {
            //Console.WriteLine();
            if (doorNorth == true)
                Console.WriteLine("there is door to the north");
            if (doorEast == true)
                Console.WriteLine("there is door to the east");
            if (doorSouth == true)
                Console.WriteLine("there is door to the south");
            if (doorWest == true)
                Console.WriteLine("there is door to the west");
        }
    }
}
