using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Player guy = new Player(); //pleyer charecter
            //rooms:
            Room entrance = new Room();
            entrance.location = -1.1;
            Room combatitro = new Room();
            combatitro.location = 1;
            Room firstitem = new Room();
            firstitem.location = 1.1;
            Room baseroom = new Room();
            baseroom.location = 0;
            Room up = new Room();
            up.location = 0.1;
            Room up2 = new Room();
            up2.location = 0.2;
            Room up3 = new Room();
            up3.location = 0.3;
            Room room03 = new Room();
            room03.location = 1.3;
            Room Streasure = new Room();
            Streasure.location = 2.3;
            Room bossroom = new Room();
            bossroom.location = 2.2;
            Room secretroom = new Room();
            secretroom.location = 2.1;
            Room intelroom = new Room();
            intelroom.location = 2.4;
            bool tellroom = true;
            double myroom = -1.1;
            double temp=100;
            while (true)
            {
                if (tellroom)
                {
                    switch (myroom)
                    {
                        case (-1.1):
                            entrance.discription(guy);
                            break;
                        case (1):
                            combatitro.discription(guy);
                            break;
                        case (1.1):
                            firstitem.discription(guy);
                            break;
                        case (0):
                            baseroom.discription(guy);
                            break;
                        case (0.1):
                            up.discription(guy);
                            break;
                        case (0.2):
                            up2.discription(guy);
                            break;
                        case (0.3):
                            up3.discription(guy);
                            break;
                        case (1.3):
                            room03.discription(guy);
                            break;
                        case (2.3):
                            Streasure.discription(guy);
                            break;
                        case (2.2):
                            bossroom.discription(guy);
                            break;
                        case 2.4:
                            intelroom.discription(guy);
                            break;
                        case 2.1:
                            secretroom.discription(guy);
                            break;
                    }
                }
                switch (myroom)
                {
                    case (-1.1):
                        temp = action(entrance, guy);
                        break;
                    case (1):
                        temp = action(combatitro, guy);
                        break;
                    case (1.1):
                        temp = action(firstitem, guy);
                        break;
                    case (0):
                        temp = action(baseroom, guy);
                        break;
                    case (0.1):
                        temp = action(up, guy);
                        break;
                    case (0.2):
                        temp = action(up2, guy);
                        break;
                    case (0.3):
                        temp = action(up3, guy);
                        break;
                    case (1.3):
                        temp = action(room03, guy);
                        break;
                    case (2.3):
                        temp = action(Streasure, guy);
                        break;
                    case (2.2):
                        temp = action(bossroom, guy);
                        break;
                    case 2.4:
                        temp = action(intelroom, guy);
                        break;
                    case 2.1:
                        temp = action(secretroom, guy);
                        break;
                }
                tellroom = (temp!=myroom);
                myroom = temp;
            }
            Console.ReadKey();
        }
        static void opdoors(Room init)
        {
            if (init.doorNorth == true)
                Console.WriteLine("(N) go through north door");
            if (init.doorEast == true)
                Console.WriteLine("(E) go through east door");
            if (init.doorSouth == true)
                Console.WriteLine("(S) go through south door");
            if (init.doorWest == true)
                Console.WriteLine("(W) go through west door");
        }
        static double moveroom(string a, Room init)
        {
            double temp=init.location;
            if (init.doorNorth == true && (a == "N" || a == "n"))
            {
                if (temp == -1.1)
                    temp += 2.1;
                else
                    temp += 0.1;
            }
            if (init.doorEast == true && (a == "E" || a == "e"))
                temp += 1;
            if (init.doorSouth == true && (a == "S" || a == "s"))
                temp -= 0.1;
            if (init.doorWest == true && (a == "W" || a == "w"))
                temp -= 1;
            return temp;
        }
        static double action(Room init, Player guy)
        {
            double nextroom=init.location;
            int counter = 1;
            if(init.monster == true) //to do
            {

            }
            else
            {
                init.doors();
                Console.WriteLine("what would you like to do?");
                switch (init.location)
                //showing options
                {
                    case (-1.1):
                        Console.WriteLine($"({counter++}) take sword");
                        Console.WriteLine($"({counter++}) take bow");
                        Console.WriteLine($"({counter++}) take staff");
                        Console.WriteLine($"({counter++}) look up");
                        opdoors(init);
                        break;
                    case (1):
                        opdoors(init);
                        break;
                    case (1.1):
                        opdoors(init);
                        break;
                    case (0):
                        opdoors(init);
                        break;
                    case (0.1):
                        opdoors(init);
                        break;
                    case (0.2):
                        opdoors(init);
                        break;
                    case (0.3):
                        opdoors(init);
                        break;
                    case (1.3):
                        opdoors(init);
                        break;
                    case (2.3):
                        opdoors(init);
                        break;
                    case (2.2):
                        opdoors(init);
                        break;
                    case 2.4:
                        opdoors(init);
                        break;
                    case 2.1:
                        opdoors(init);
                        break;
                }
                string letsdo = Console.ReadLine();
                switch (init.location)
                //picking options
                {
                    case (-1.1):
                        switch (letsdo)
                        {
                            case "1":
                                init.getWepon(guy, 1);
                                break;
                            case "2":
                                init.getWepon(guy, 2);
                                break;
                            case "3":
                                init.getWepon(guy, 3);
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (1):
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (1.1):
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (0):
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (0.1):
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (0.2):
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (0.3):
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (1.3):
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (2.3):
                        //boss room
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case (2.2):
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case 2.4:
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                    case 2.1:
                        switch (letsdo)
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "N":
                            case "n":
                            case "E":
                            case "e":
                            case "S":
                            case "s":
                            case "W":
                            case "w":
                                nextroom = moveroom(letsdo, init);
                                break;
                            default:
                                Console.WriteLine("what?");
                                break;
                        }
                        break;
                }
            }
            return nextroom;
        }
    }
}
