using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Classes
{
    public class EliminationSpieler
    {
        public string Name { get; set; }

        //Für die einzelne Runde
        public int Score { get; set; }

        public EliminationSpieler(string name) {
            Name = name;
        }
    }
}
