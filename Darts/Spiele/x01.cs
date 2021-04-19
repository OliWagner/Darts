using Darts.Classes;
using Darts.Interfaces;
using Darts.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Darts.Spiele
{
    public class X01 : MainSpiel, IMainSpiel
    {
        public UcWurfanzeigeX01 Anzeige;
        public UcTableX01 UcTabelle;
        MainWindow Window;
        public int StartScore = 0;
        public int AnzahlSpieler = 0;
        public int SpielerDran = 0;
        public int SpielerGestartet = 0;

        public X01(Grid wurfanzeige, Grid tabelle, List<Spieler> spieler, UcScheibe dartboard, int startscore, MainWindow window) {
            AnzahlSpieler = spieler.Count();
            StartScore = startscore;
            Mitspieler = spieler;
            foreach (Spieler item in Mitspieler)
            {
                item.Score = startscore;
            }
            Window = window;
            Window.OnSpielerNeu += MainWindow_OnSpielerNeu;
            Window.OnSpielWechsel += Mainwindow_OnSpielWechsel;

            Wurfanzeige = wurfanzeige;
            Tabelle = tabelle;
            Dartscheibe = dartboard;
            Dartscheibe.IsEnabled = true;
            Dartscheibe.BtnBack.Click += BtnBack_Click;
            foreach (Control item in Dartscheibe.grdMain.Children) {
                if (item.GetType() == typeof(Label)) {
                    item.MouseDoubleClick += Dartscheibe_MouseDoubleClick;
                }
            }
            ZeichneGridWurfanzeige();
            ZeichneGridTabelle();
        }

        public void ZeichneGridTabelle()
        {
            Tabelle.Children.Clear();
            UcTabelle = new UcTableX01(Mitspieler, Window);
            UcTabelle.ZeichneTabelle();
            Tabelle.Children.Add(UcTabelle);
        }

        public void ZeichneGridWurfanzeige()
        {
            Wurfanzeige.Children.Clear();
            Anzeige = new UcWurfanzeigeX01(Mitspieler[SpielerDran].Name, Window);
            Anzeige.BtnFertig.Click += AnzeigeBtnFertig_Click;
            Wurfanzeige.Children.Add(Anzeige);
        }

        public void NextRunde()
        {
            if (SpielerGestartet < (Mitspieler.Count() - 1))
            {
                SpielerGestartet++;
            }
            else
            {
                SpielerGestartet = 0;
            }
            SpielerDran = SpielerGestartet;
        }

        public void NextSpieler() {
            if (SpielerDran < (Mitspieler.Count() - 1))
            {
                SpielerDran++;
            }
            else {
                SpielerDran = 0;
            }
        }

        public void Reset() {
            Anzeige.Score1 = null;
            Anzeige.Score2 = null;
            Anzeige.Score3 = null;
        }

        private int scoreSpielerDieseRunde = 0;
        private void CheckWurf(int score, int wurf) {
            scoreSpielerDieseRunde += score;
            if (Mitspieler[SpielerDran].Score < scoreSpielerDieseRunde) {
                //Spieler hat sich überworfen
                Dartscheibe.IsEnabled = false;
                NextSpieler();                
                Anzeige.BtnFertig.Visibility = Visibility.Visible;
            }
            else if (Mitspieler[SpielerDran].Score == scoreSpielerDieseRunde) {
                //Spieler hat gewonnen
                Dartscheibe.IsEnabled = false;
                Mitspieler[SpielerDran].Siege++;
                foreach (Spieler s in Mitspieler) {
                    s.Score = StartScore;
                }
                NextRunde();
                Anzeige.BtnFertig.Content = "Neu";
                Anzeige.BtnFertig.Visibility = Visibility.Visible;
            }
            else {
                //Wurf wird vom Score abgezogen
                if (wurf == 1) { Anzeige.Score1 = score.ToString(); }
                if (wurf == 2) { Anzeige.Score2 = score.ToString(); }
                if (wurf == 3) { Anzeige.Score3 = score.ToString(); }
               
                if (wurf == 3) {
                    Mitspieler[SpielerDran].Score -= scoreSpielerDieseRunde;
                    NextSpieler();
                    Dartscheibe.IsEnabled = false;
                    Anzeige.BtnFertig.Visibility = Visibility.Visible;
                } 
            }

        }

        public void Mainwindow_OnSpielWechsel(object myObject, EventArgs myArgs)
        {
            this.Window.grdMain.Children.Remove(this.UcTabelle);
            this.Window.grdMain.Children.Remove(this.Anzeige);
            Window.OnSpielWechsel -= Mainwindow_OnSpielWechsel;
            foreach (Control item in Dartscheibe.grdMain.Children)
            {
                if (item.GetType() == typeof(Label))
                {
                    item.MouseDoubleClick -= Dartscheibe_MouseDoubleClick;
                }
            }
        }

        public void MainWindow_OnSpielerNeu(object myObject, EventArgs myArgs)
        {
            MainWindow win = (MainWindow)myObject;
            Mitspieler = win.Mitspieler;
            foreach (Spieler spieler in Mitspieler)
            {
                spieler.Score = StartScore;
            }
            Reset();

            AnzahlSpieler = Mitspieler.Count();
            SpielerDran = 0;
            SpielerGestartet = 0;
            ZeichneGridTabelle();
            ZeichneGridWurfanzeige();
        }

        public void AnzeigeBtnFertig_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Dartscheibe.BtnBack.Visibility = Visibility.Hidden;
            scoreSpielerDieseRunde = 0;
            Anzeige.BtnFertig.Content = "Weiter";
            Dartscheibe.IsEnabled = true;
            Reset();
            ZeichneGridTabelle();
            ZeichneGridWurfanzeige();
        }



        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Dartscheibe_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Label _sender = (Label)sender;
            int ergebnis = Int32.Parse(_sender.Tag.ToString());
            if (Anzeige.Score1 == null && Anzeige.Score2 == null && Anzeige.Score3 == null)
            {
                Anzeige.Score1 = ergebnis.ToString();
                CheckWurf(ergebnis, 1);
                ZeichneGridTabelle();
                return;
            }
            if (Anzeige.Score1 != null && Anzeige.Score2 == null && Anzeige.Score3 == null)
            {
                Anzeige.Score2 = ergebnis.ToString();
                CheckWurf(ergebnis, 2);
                ZeichneGridTabelle();
                return;
            }
            if (Anzeige.Score1 != null && Anzeige.Score2 != null && Anzeige.Score3 == null)
            {
                Anzeige.Score3 = ergebnis.ToString();
                CheckWurf(ergebnis, 3);
                ZeichneGridTabelle();
                return;
            }

            ZeichneGridWurfanzeige();
        }
    }
}
