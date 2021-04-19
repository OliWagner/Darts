using Darts.Classes;
using Darts.Interfaces;
using Darts.UserControls;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Darts.Spiele
{
    public class MainSpiel
    {
        public List<Spieler> Mitspieler { get; set; }
        public Grid Wurfanzeige { get; set; }
        public Grid Tabelle  { get; set; }
        public UcScheibe Dartscheibe { get; set; }
    }
}
