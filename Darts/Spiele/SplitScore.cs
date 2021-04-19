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
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Darts.Spiele
{
    public class SplitScore : MainSpiel, IMainSpiel
    {
        public UcWurfAnzeigeSplitScore Anzeige;
        public UcTableSplitScore UcTabelle;
        public List<SplitScoreSpieler> SplitScoreMitSpieler = new List<SplitScoreSpieler>();
        public int Wuerfe = 0;
        private int Runde = 0;
        private List<int> WurfrundenVorgabenWerte = new List<int> { 15, 16, 0, 17, 18, 0, 19, 20, 25 };
        private List<string> WurfrundenVorgabenBezeichnungen = new List<string> { "15", "16", "D", "17", "18", "T", "19", "20", "B" };
        MainWindow Mainwindow;
        public int AnzahlSpieler = 0;
        public int SpielerDran = 0;
        public int SpielerGestartet = 0;
        private bool getroffen = false;

        public SplitScore(Grid wurfanzeige, Grid tabelle, List<Spieler> spieler, UcScheibe dartboard, MainWindow window)
        {
            Mainwindow = window;
            Mainwindow.OnSpielWechsel += Mainwindow_OnSpielWechsel;
            AnzahlSpieler = spieler.Count();
            Mitspieler = spieler;
            ErzeugeSplitScoreSpieler();
            window.OnSpielerNeu += MainWindow_OnSpielerNeu;

            Wurfanzeige = wurfanzeige;
            Tabelle = tabelle;
            Dartscheibe = dartboard;
            Dartscheibe.IsEnabled = true;
            Dartscheibe.BtnBack.Click += BtnBack_Click;
            foreach (Control item in Dartscheibe.grdMain.Children)
            {
                if (item.GetType() == typeof(Label))
                {
                    item.MouseDoubleClick += Dartscheibe_MouseDoubleClick;
                }
            }
            ZeichneGridWurfanzeige();
            ZeichneGridTabelle();
        }


        public void ZeichneGridTabelle()
        {
            Tabelle.Children.Clear();
            UcTabelle = new UcTableSplitScore(SplitScoreMitSpieler, Mainwindow);
            Tabelle.Children.Add(UcTabelle);
        }

        public void ZeichneGridWurfanzeige()
        {
            Wurfanzeige.Children.Clear();
            Anzeige = new UcWurfAnzeigeSplitScore(Mainwindow);
            Anzeige.LblName.Content = SplitScoreMitSpieler[SpielerDran].Name;
            Anzeige.LblScore.Content = SplitScoreMitSpieler[SpielerDran].Score;
            Anzeige.LblZiel.Content = WurfrundenVorgabenBezeichnungen[Runde];
            Anzeige.BtnFertig.Click += AnzeigeBtnFertig_Click;
            Wurfanzeige.Children.Add(Anzeige);
        }

        public void NextSpieler()
        {
            if (SpielerDran < (SplitScoreMitSpieler.Count() - 1))
            {
                SpielerDran++;
            }
            else
            {
                SpielerDran = 0;
                Runde++;
            }
        }

        public void NextRunde()
        {
            if (SpielerGestartet < (SplitScoreMitSpieler.Count() - 1))
            {
                SpielerGestartet++;
            }
            else
            {
                SpielerGestartet = 0;
            }
            SpielerDran = SpielerGestartet;
            Runde = 0;
        }

        private void CheckWurf(int score)
        {
            if (score != 0 && WurfrundenVorgabenWerte[Runde] != 0 && score % WurfrundenVorgabenWerte[Runde] == 0 && !(Runde == 0 && score == 60))
            {
                getroffen = true;
                SplitScoreMitSpieler[SpielerDran].Score += score;
                Anzeige.Score = score;
                switch (Runde)
                {
                    case 0: SplitScoreMitSpieler[SpielerDran].Score15 += score; break;
                    case 1: SplitScoreMitSpieler[SpielerDran].Score16 += score; break;
                    case 2: SplitScoreMitSpieler[SpielerDran].ScoreD += score; break;
                    case 3: SplitScoreMitSpieler[SpielerDran].Score17 += score; break;
                    case 4: SplitScoreMitSpieler[SpielerDran].Score18 += score; break;
                    case 5: SplitScoreMitSpieler[SpielerDran].ScoreT += score; break;
                    case 6: SplitScoreMitSpieler[SpielerDran].Score19 += score; break;
                    case 7: SplitScoreMitSpieler[SpielerDran].Score20 += score; break;
                    case 8: SplitScoreMitSpieler[SpielerDran].ScoreB += score; break;
                }

            }
            if (score != 0 && WurfrundenVorgabenWerte[Runde] == 0)
            {
                getroffen = true;
                SplitScoreMitSpieler[SpielerDran].Score += score;
                Anzeige.Score = score;
                switch (Runde)
                {
                    case 2: SplitScoreMitSpieler[SpielerDran].ScoreD += score; break;
                    case 5: SplitScoreMitSpieler[SpielerDran].ScoreT += score; break;
                }
            }
        }

        public void ErzeugeSplitScoreSpieler()
        {
            SplitScoreMitSpieler.Clear();
            foreach (Spieler item in Mitspieler)
            {
                SplitScoreSpieler cms = new SplitScoreSpieler(item);
                SplitScoreMitSpieler.Add(cms);
            }
        }


        public void Mainwindow_OnSpielWechsel(object myObject, EventArgs myArgs)
        {
            this.Mainwindow.grdMain.Children.Remove(this.UcTabelle);
            this.Mainwindow.grdMain.Children.Remove(this.Anzeige);
            Mainwindow.OnSpielWechsel -= Mainwindow_OnSpielWechsel;
            foreach (Control item in Dartscheibe.grdMain.Children)
            {
                if (item.GetType() == typeof(Label))
                {
                    item.MouseDoubleClick -= Dartscheibe_MouseDoubleClick;
                }
            }
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Dartscheibe_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Wuerfe++;
            string path = "pack://application:,,,/Images/" + Wuerfe + "wuerfe.png";
            var image = new BitmapImage(new Uri(path));
            Anzeige.ImgWuerfe.Source = image;
            Label _sender = (Label)sender;
            int score = Int32.Parse(_sender.Tag.ToString());
            CheckWurf(score);
            if (Wuerfe == 3)
            {
                if (!getroffen) {
                    SplitScoreMitSpieler[SpielerDran].Score /= 2;
                }
                Dartscheibe.IsEnabled = false;

                Anzeige.BtnFertig.Visibility = Visibility.Visible;
                if (Runde == 8 && SpielerDran == SplitScoreMitSpieler.Count - 1)
                {
                    Anzeige.BtnFertig.Content = "Neu";
                }
            }
            UcTabelle.ZeichneTabelle();
        }

        public void AnzeigeBtnFertig_Click(object sender, RoutedEventArgs e)
        {
            Dartscheibe.BtnBack.Visibility = Visibility.Hidden;
            if (Anzeige.BtnFertig.Content.Equals("Neu"))
            {
                Anzeige.BtnFertig.Content = "Weiter";
                NextRunde();
                SplitScoreMitSpieler.OrderByDescending(x => x.Score).FirstOrDefault().Siege++;
                foreach (SplitScoreSpieler item in SplitScoreMitSpieler)
                {
                    item.Reset();
                }
            }
            else {
                NextSpieler();
            }
            getroffen = false;
            Wuerfe = 0;
            string path = "pack://application:,,,/Images/" + Wuerfe + "wuerfe.png";
            var image = new BitmapImage(new Uri(path));
            Anzeige.ImgWuerfe.Source = image;
            Dartscheibe.IsEnabled = true;
            ZeichneGridTabelle();
            ZeichneGridWurfanzeige();
        }

        public void MainWindow_OnSpielerNeu(object myObject, EventArgs myArgs)
        {
            MainWindow win = (MainWindow)myObject;
            Mitspieler = win.Mitspieler;
            ErzeugeSplitScoreSpieler();
            AnzahlSpieler = Mitspieler.Count();
            SpielerDran = 0;
            SpielerGestartet = 0;
            ZeichneGridTabelle();
            ZeichneGridWurfanzeige();
            Wuerfe = 0;
            string path = "pack://application:,,,/Images/" + Wuerfe + "wuerfe.png";
            var image = new BitmapImage(new Uri(path));
            Anzeige.ImgWuerfe.Source = image;
            Runde = 0;
            Dartscheibe.IsEnabled = true;
            getroffen = false;
        }

        

        

        
    }
}
