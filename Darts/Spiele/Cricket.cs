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
    public class Cricket : MainSpiel, IMainSpiel
    {
        public UcWurfanzeigeCricketxaml Anzeige;
        public UcTableCricket UcTabelle;
        public List<CricketSpieler> CricketMitSpieler = new List<CricketSpieler>();
        private int Wuerfe = 0;
        private MainWindow Window;

        public int AnzahlSpieler = 0;
        public int SpielerDran = 0;
        public int SpielerGestartet = 0;

        public Cricket(Grid wurfanzeige, Grid tabelle, List<Spieler> spieler, UcScheibe dartboard, MainWindow window) {
            AnzahlSpieler = spieler.Count();
            Mitspieler = spieler;
            ErzeugeCricketSpieler();
            Window = window;
            Window.OnSpielerNeu += MainWindow_OnSpielerNeu;
            Window.OnSpielWechsel += Mainwindow_OnSpielWechsel;
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
            UcTabelle = new UcTableCricket(CricketMitSpieler, Window);
            Tabelle.Children.Add(UcTabelle);
        }

        public void ZeichneGridWurfanzeige()
        {
            Wurfanzeige.Children.Clear();
            Anzeige = new UcWurfanzeigeCricketxaml(Window);
            Anzeige.LblSpielerName.Content = Mitspieler[SpielerDran].Name;
            Anzeige.BtnFertig.Click += AnzeigeBtnFertig_Click;
            Wurfanzeige.Children.Add(Anzeige);
        }

        public void NextSpieler()
        {
            if (SpielerDran < (CricketMitSpieler.Count() - 1))
            {
                SpielerDran++;
            }
            else
            {
                SpielerDran = 0;
            }
        }

        public void NextRunde()
        {
            if (SpielerGestartet < (CricketMitSpieler.Count() - 1))
            {
                SpielerGestartet++;
            }
            else
            {
                SpielerGestartet = 0;
            }
            SpielerDran = SpielerGestartet;
        }

        private bool FeldGeschlossen(int feld, CricketSpieler cs) {
            switch (feld) {
                case 15:
                    foreach (CricketSpieler spieler in CricketMitSpieler.Where(x => x != cs))
                    {
                        if (spieler.Wuerfe15 < 3) {
                            return false;
                        }
                    }
                    break;

                case 16:
                    foreach (CricketSpieler spieler in CricketMitSpieler.Where(x => x != cs))
                    {
                        if (spieler.Wuerfe16 < 3)
                        {
                            return false;
                        }
                    }
                    break;

                case 17:
                    foreach (CricketSpieler spieler in CricketMitSpieler.Where(x => x != cs))
                    {
                        if (spieler.Wuerfe17 < 3)
                        {
                            return false;
                        }
                    }
                    break;

                case 18:
                    foreach (CricketSpieler spieler in CricketMitSpieler.Where(x => x != cs))
                    {
                        if (spieler.Wuerfe18 < 3)
                        {
                            return false;
                        }
                    }
                    break;

                case 19:
                    foreach (CricketSpieler spieler in CricketMitSpieler.Where(x => x != cs))
                    {
                        if (spieler.Wuerfe19 < 3)
                        {
                            return false;
                        }
                    }
                    break;

                case 20:
                    foreach (CricketSpieler spieler in CricketMitSpieler.Where(x => x != cs))
                    {
                        if (spieler.Wuerfe20 < 3)
                        {
                            return false;
                        }
                    }
                    break;

                case 25:
                    foreach (CricketSpieler spieler in CricketMitSpieler.Where(x => x != cs))
                    {
                        if (spieler.WuerfeB < 3)
                        {
                            return false;
                        }
                    }
                    break;

            }
            return true;
        }

        private void CheckObSpielerFertig(CricketSpieler spieler) {
            if (spieler.Wuerfe15 == 3 && spieler.Wuerfe16 == 3 && spieler.Wuerfe17 == 3 && 
                spieler.Wuerfe18 == 3 && spieler.Wuerfe19 == 3 && spieler.Wuerfe20 == 3 && spieler.WuerfeB == 3) {
                if (CricketMitSpieler.Where(x => x != spieler).OrderByDescending(x => x.Score).FirstOrDefault().Score <= spieler.Score) {
                    //Spieler hat gewonnen
                    Dartscheibe.IsEnabled = false;
                    Anzeige.BtnFertig.Content = "Neues Spiel";
                    Anzeige.BtnFertig.Visibility = Visibility.Visible;
                }
            }
        }
        
        private void SetSpielerScore(int wert, int score) {
            switch (wert) {
                case 15:
                    CricketMitSpieler[SpielerDran].Wuerfe15 += score / 15;
                    if (CricketMitSpieler[SpielerDran].Wuerfe15 > 3) {
                        if(!FeldGeschlossen(15, CricketMitSpieler[SpielerDran])) { 
                        CricketMitSpieler[SpielerDran].Score += (CricketMitSpieler[SpielerDran].Wuerfe15 - 3) * 15;
                        }
                        CricketMitSpieler[SpielerDran].Wuerfe15 = 3;
                    }
                    break;
                case 16:
                    CricketMitSpieler[SpielerDran].Wuerfe16 += score / 16;
                    if (CricketMitSpieler[SpielerDran].Wuerfe16 > 3)
                    {
                        if (!FeldGeschlossen(16, CricketMitSpieler[SpielerDran]))
                        {
                            CricketMitSpieler[SpielerDran].Score += (CricketMitSpieler[SpielerDran].Wuerfe16 - 3) * 16;
                        }
                        CricketMitSpieler[SpielerDran].Wuerfe16 = 3;
                    }
                    break;
                case 17:
                    CricketMitSpieler[SpielerDran].Wuerfe17 += score / 17;
                    if (CricketMitSpieler[SpielerDran].Wuerfe17 > 3)
                    {
                        if (!FeldGeschlossen(17, CricketMitSpieler[SpielerDran]))
                        {
                            CricketMitSpieler[SpielerDran].Score += (CricketMitSpieler[SpielerDran].Wuerfe17 - 3) * 17;
                        }
                        CricketMitSpieler[SpielerDran].Wuerfe17 = 3;
                    }
                    break;
                case 18:
                    CricketMitSpieler[SpielerDran].Wuerfe18 += score / 18;
                    if (CricketMitSpieler[SpielerDran].Wuerfe18 > 3)
                    {
                        if (!FeldGeschlossen(18, CricketMitSpieler[SpielerDran]))
                        {
                            CricketMitSpieler[SpielerDran].Score += (CricketMitSpieler[SpielerDran].Wuerfe18 - 3) * 18;
                        }
                        CricketMitSpieler[SpielerDran].Wuerfe18 = 3;
                    }
                    break;
                case 19:
                    CricketMitSpieler[SpielerDran].Wuerfe19 += score / 19;
                    if (CricketMitSpieler[SpielerDran].Wuerfe19 > 3)
                    {
                        if (!FeldGeschlossen(19, CricketMitSpieler[SpielerDran]))
                        {
                            CricketMitSpieler[SpielerDran].Score += (CricketMitSpieler[SpielerDran].Wuerfe19 - 3) * 19;
                        }
                        CricketMitSpieler[SpielerDran].Wuerfe19 = 3;
                    }
                    break;
                case 20:
                    CricketMitSpieler[SpielerDran].Wuerfe20 += score / 20;
                    if (CricketMitSpieler[SpielerDran].Wuerfe20 > 3)
                    {
                        if (!FeldGeschlossen(20, CricketMitSpieler[SpielerDran]))
                        {
                            CricketMitSpieler[SpielerDran].Score += (CricketMitSpieler[SpielerDran].Wuerfe20 - 3) * 20;
                        }
                        CricketMitSpieler[SpielerDran].Wuerfe20 = 3;
                    }
                    break;
                case 25:
                    CricketMitSpieler[SpielerDran].WuerfeB += score / 25;
                    if (CricketMitSpieler[SpielerDran].WuerfeB > 3)
                    {
                        if (!FeldGeschlossen(25, CricketMitSpieler[SpielerDran]))
                        {
                            CricketMitSpieler[SpielerDran].Score += (CricketMitSpieler[SpielerDran].WuerfeB - 3) * 25;
                        }
                        CricketMitSpieler[SpielerDran].WuerfeB = 3;
                    }
                    break;
            }
            CheckObSpielerFertig(CricketMitSpieler[SpielerDran]);
        }

        private void CheckWurf(int wurf) {
            if (wurf % 15 == 0 && wurf < 46)
            {
                SetSpielerScore(15, wurf);
            }
            if (wurf % 16 == 0)
            {
                SetSpielerScore(16, wurf);
            }
            if (wurf % 17 == 0)
            {
                SetSpielerScore(17, wurf);
            }
            if (wurf % 18 == 0)
            {
                SetSpielerScore(18, wurf);
            }
            if (wurf % 19 == 0)
            {
                SetSpielerScore(19, wurf);
            }
            if (wurf % 20 == 0)
            {
                SetSpielerScore(20, wurf);
            }
            if (wurf % 25 == 0)
            {
                SetSpielerScore(25, wurf);
            }
        }

        private void ErzeugeCricketSpieler() {
            CricketMitSpieler.Clear();
            foreach (Spieler item in Mitspieler)
            {
                CricketSpieler cms = new CricketSpieler(item);
                CricketMitSpieler.Add(cms);
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

        public void AnzeigeBtnFertig_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Dartscheibe.BtnBack.Visibility = Visibility.Hidden;
            if (Anzeige.BtnFertig.Content.Equals("Neues Spiel"))
            {
                foreach (CricketSpieler item in CricketMitSpieler)
                {
                    item.Reset();
                }
                NextRunde();
            }

            Wuerfe = 0;
            string path = "pack://application:,,,/Images/" + Wuerfe + "wuerfe.png";
            var image = new BitmapImage(new Uri(path));
            Anzeige.ImgWuerfe.Source = image;
            Anzeige.BtnFertig.Content = "Weiter";
            Anzeige.BtnFertig.Visibility = Visibility.Hidden;
            Dartscheibe.IsEnabled = true;
            NextSpieler();
            Anzeige.LblSpielerName.Content = CricketMitSpieler[SpielerDran].Name;
            ZeichneGridTabelle();
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
            if (Wuerfe == 3) {
                Dartscheibe.IsEnabled = false;
                Anzeige.BtnFertig.Visibility = Visibility.Visible;
            }
            ZeichneGridTabelle();
        }

        public void MainWindow_OnSpielerNeu(object myObject, EventArgs myArgs)
        {
            MainWindow win = (MainWindow)myObject;
            Mitspieler = win.Mitspieler;
            ErzeugeCricketSpieler();
            AnzahlSpieler = Mitspieler.Count();
            SpielerDran = 0;
            SpielerGestartet = 0;
            ZeichneGridTabelle();
            ZeichneGridWurfanzeige();
            Wuerfe = 0;
            string path = "pack://application:,,,/Images/" + Wuerfe + "wuerfe.png";
            var image = new BitmapImage(new Uri(path));
            Anzeige.ImgWuerfe.Source = image;
            Dartscheibe.IsEnabled = true;
        }
    }
}
