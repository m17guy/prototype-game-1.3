using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1._3
{
    class Monster
    {
        public static int level=0;
        public int hp = 20 + level;
        public int damage;
        public string name;
        public bool isalive = true;
        public Monster()
        {
            level++;
        }
    }
}
