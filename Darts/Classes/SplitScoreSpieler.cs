using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Classes
{
    public class SplitScoreSpieler
    {
        public string Name { get; set; }

        //Für die einzelne Runde
        public int Score = 40;

        public int Score15 = 0;
        public int Score16 = 0;
        public int ScoreD = 0;
        public int Score17 = 0;
        public int Score18 = 0;
        public int ScoreT = 0;
        public int Score19 = 0;
        public int Score20 = 0;
        public int ScoreB = 0;
        public int Siege = 0;

        public SplitScoreSpieler(Spieler spieler)
        {
            Name = spieler.Name;
        }

        public void Reset()
        {
            Score = 40;
            Score15 = 0;
            Score16 = 0;
            ScoreD = 0;
            Score17 = 0;
            Score18 = 0;
            ScoreT = 0;
            Score19 = 0;
            Score20 = 0;
            ScoreB = 0;
        }
    }
}
