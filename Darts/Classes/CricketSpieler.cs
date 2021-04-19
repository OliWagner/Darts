using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Classes
{
    public class CricketSpieler
    {
        public string Name { get; set; }

        //Für die einzelne Runde
        public int Score = 0;

        public int Wuerfe15 = 0;
        public int Wuerfe16 = 0;
        public int Wuerfe17 = 0;
        public int Wuerfe18 = 0;
        public int Wuerfe19 = 0;
        public int Wuerfe20 = 0;
        public int WuerfeB = 0;

        public CricketSpieler(Spieler spieler) {
            Name = spieler.Name;
        }

        public void Reset() {
            Score = 0;
            Wuerfe15 = 0;
            Wuerfe16 = 0;
            Wuerfe17 = 0;
            Wuerfe18 = 0;
            Wuerfe19 = 0;
            Wuerfe20 = 0;
            WuerfeB = 0;
        }
    }
}
