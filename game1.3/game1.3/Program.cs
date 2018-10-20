using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace game1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream("monster list.txt", FileMode.OpenOrCreate);
            file.Close();//never forget to close the stream
            //making the monsters
            string[] monsterAtributs = File.ReadAllText("monster list.txt").Split('\n');
            Monster test = new Monster();
            test.name = monsterAtributs[0];
            test.hp = Convert.ToInt32(monsterAtributs[1]);
            test.knows = Convert.ToBoolean(monsterAtributs[2]);
            Console.WriteLine($"{test.name}\n{test.hp}\n{test.knows}"); //works so far
            
            
            Player guy = new Player(); //pleyer charecter ********* maybe to be made into a singelton
            //rooms:
            Room entrance = new Room();
            entrance.location = -1.1;
            Room combatitro = new Room();
            //im only puting him here for testing perpeses
            combatitro.Mhere = test;

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
            double temp = 100;
            for (int i = 0; i < 150; i++)
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
                        default:
                            Console.WriteLine("GAME OVER");
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
                tellroom = (temp != myroom);
                myroom = temp;
            }
            //small funny ending if it takes you too long
            Console.WriteLine("you hear the walls shacking around you, theyre croumbling");
            Console.WriteLine("rocks start faling on you, you should have seen this coming");
            Console.WriteLine("GAME OVER");
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
            a = a.ToLower();
            double temp=init.location;
            if (a == "n")
            {
                if (init.doorNorth == true)
                {
                    if (temp == -1.1)
                    {
                        temp *= 10;
                        temp += 21;
                        temp /= 10;
                    }
                    else
                    {
                        temp *= 10;
                        temp += 1;
                        temp /= 10;
                    }
                }
                else
                    Console.WriteLine("there is no door to the north");
            }
            if ( a == "e")
            {
                if (init.doorEast == true)
                {
                    temp *= 10;
                    temp += 10;
                    temp /= 10;
                }
                else
                    Console.WriteLine("there is no door to the east");
            }
            if (a == "s")
            {
                if (init.doorSouth == true)
                {
                    if (temp == 1)
                    {
                        temp *= 10;
                        temp -= 21;
                        temp /= 10;
                    }
                    else
                    {
                        temp *= 10;
                        temp -= 1;
                        temp /= 10;
                    }
                }
                else
                    Console.WriteLine("there is no door to the south");
            }
            if (a == "w")
            {
                if (init.doorWest == true)
                {
                    temp *= 10;
                    temp -= 10;
                    temp /= 10;
                }
                else
                    Console.WriteLine("there is no door to the west");
            }
            return temp;
        }
        static void battle(Player guy, Monster villin)
        {
            Console.WriteLine("(1) punch it in the face");
            switch (guy.job)
            {
                case 1:
                    Console.WriteLine("(2) hit it with your sword");
                    break;
                case 2:
                    Console.WriteLine("(2) shoot it with your bow");
                    break;
                case 3:
                    Console.WriteLine("(2) cast a spell at it");
                    break;
            }
            if(guy.potion>0)
                Console.WriteLine("(p) drink a potion");
            Console.WriteLine("(run) run away");
            string letsdo = Console.ReadLine().ToLower();
            switch (letsdo)
            {
                case "1":
                    Console.WriteLine("you punch it");
                    break;
                case "2":
                    switch (guy.job)
                    {
                        case 1:
                            Console.WriteLine("youve hit it with your sword");
                            break;
                        case 2:
                            Console.WriteLine("(2) shoot it with your bow");
                            break;
                        case 3:
                            Console.WriteLine("(2) cast a spell at it");
                            break;
                    }
                    break;
            }
        }
        static double action(Room init, Player guy)
        {
            double nextroom=init.location;
            int counter = 1;
            if (init.IsMonster == true && init.Mhere.knows == true) //doing
            {
                Console.WriteLine("you prepare to attack");
                battle(guy, init.Mhere);
                if (guy.hp <= 0)
                    return 9999;
            }
            else
            {
                init.doors();
                Console.WriteLine();
                Console.WriteLine("what would you like to do?");
                switch (init.location)
                //showing options
                {
                    case (-1.1):
                        if (init.weaponSword == true)
                            Console.WriteLine($"({counter++}) take sword");
                        else
                            counter++;
                        if (init.weaponBow == true)
                            Console.WriteLine($"({counter++}) take bow");
                        else
                            counter++;
                        if (init.weaponStaff == true)
                            Console.WriteLine($"({counter++}) take staff");
                        else
                            counter++;
                        Console.WriteLine($"({counter++}) look up");
                        opdoors(init);
                        break;
                    case (1):
                        Console.WriteLine($"({counter++}) attack the skeleton");
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
                Console.Clear();
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
                                battle(guy, init.Mhere);
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
