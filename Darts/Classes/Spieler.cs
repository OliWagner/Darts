using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Classes
{
    public class Spieler
    {
        public string Name { get; set; }
        public int Siege { get; set; }
        //public bool IsActive { get; set; }

        //Für die einzelne Runde
        public int Score { get; set; }

        public Spieler(string name) {
            Siege = 0;
            Name = name;

        }
    }
}
