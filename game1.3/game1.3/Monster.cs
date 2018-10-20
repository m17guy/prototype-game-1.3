using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace game1._3
{
    class Monster
    {
        
        //public static int level=0;       work in progres
        public int hp;
        public int damage;
        public int weekTo;//number corolates to player job
        public string name;
        public bool isalive = true;
        public bool knows;//knows you are here
        public bool suprise = false;//is suprising you and you dont get a free atack and it gos first
        
        public Monster()
        {
           
        }
    }
}
