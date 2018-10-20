using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1._3
{
    class Player
    {
        public static int level = 1;
        public int hp = 40;
        //public int damage; to see if needed
        public int potion = 0;
        public int job = 0;
        //more like wepon im i right
        //0=punch,1=sword,2=bow,3=wizerd
        public string name;
        public void getPotion()
        {
            potion++;
        }
        public void usePotion()
        {
            Console.WriteLine("you drink the potion and feel your strangth return to you");
            potion--;
            hp += 15;
        }
    }
}
