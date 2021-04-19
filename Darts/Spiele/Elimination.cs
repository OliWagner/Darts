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
    public class Elimination : MainSpiel, IMainSpiel
    {
        public UcWurfanzeigeElimination Anzeige;
        public UcTableElimination UcTabelle;
        MainWindow Window;
        public List<EliminationSpieler> EliminationMitspieler = new List<EliminationSpieler>();
        public int StartScore = 0;
        public int AnzahlSpieler = 0;
        public int SpielerDran = 0;
        public int SpielerGestartet = 0;
        public int Runde = 0;
        public int Wuerfe = 0;

        public Elimination(Grid wurfanzeige, Grid tabelle, List<Spieler> spieler, UcScheibe dartboard, MainWindow window) {
            
            Window = window;

            Mitspieler = spieler;
            ErzeugeEliminationSpieler();

            Wurfanzeige = wurfanzeige;
            Tabelle = tabelle;

            Window.OnSpielerNeu += MainWindow_OnSpielerNeu;
            Window.OnSpielWechsel += Mainwindow_OnSpielWechsel;

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
            UcTabelle = new UcTableElimination(EliminationMitspieler, Runde + 1, Window);
            UcTabelle.ZeichneTabelle();
            Tabelle.Children.Add(UcTabelle);
        }

        public void ZeichneGridWurfanzeige()
        {
            Wurfanzeige.Children.Clear();
            if (Anzeige == null)
            {
                Anzeige = new UcWurfanzeigeElimination(EliminationMitspieler[SpielerDran].Name, EliminationMitspieler[SpielerDran].Score, Window);
                Anzeige.BtnFertig.Click += AnzeigeBtnFertig_Click;
            }
            else { 
                Anzeige.LblName.Content = EliminationMitspieler[SpielerDran].Name;
                Anzeige.Score = EliminationMitspieler[SpielerDran].Score;
            }
            
            Wurfanzeige.Children.Add(Anzeige);
        }

        public void NextRunde()
        {
            if (SpielerGestartet < (EliminationMitspieler.Count() - 1))
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

        public void NextSpieler()
        {
            if (SpielerDran < (EliminationMitspieler.Count() - 1))
            {
                SpielerDran++;
            }
            else
            {
                SpielerDran = 0;
                Runde++;
            }
        }

        public void ErzeugeEliminationSpieler()
        {
            EliminationMitspieler.Clear();
            foreach (Spieler item in Mitspieler)
            {
                EliminationSpieler cms = new EliminationSpieler(item.Name);
                EliminationMitspieler.Add(cms);
            }
        }


        public void AnzeigeBtnFertig_Click(object sender, RoutedEventArgs e)
        {
            Dartscheibe.BtnBack.Visibility = Visibility.Hidden;
            Anzeige.BtnFertig.Visibility = Visibility.Hidden;
            if (Anzeige.BtnFertig.Content.Equals("Neu"))
            {
                Anzeige.BtnFertig.Content = "Weiter";
                NextRunde();

                foreach (EliminationSpieler item in EliminationMitspieler)
                {
                    item.Score = 0;
                }
            }
            else
            {
                NextSpieler();
            }

            Wuerfe = 0;
            string path = "pack://application:,,,/Images/" + Wuerfe + "wuerfe.png";
            var image = new BitmapImage(new Uri(path));
            Anzeige.ImgWuerfe.Source = image;
            Dartscheibe.IsEnabled = true;
            ZeichneGridTabelle();
            ZeichneGridWurfanzeige();
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
            int ergebnis = Int32.Parse(_sender.Tag.ToString());
            CheckWurf(ergebnis);
            if (Wuerfe == 3) {
                Dartscheibe.IsEnabled = false;

                Anzeige.BtnFertig.Visibility = Visibility.Visible;

                if (Runde == 9 && SpielerDran == EliminationMitspieler.Count - 1)
                {
                    Anzeige.BtnFertig.Content = "Neu";
                }
            }
            ZeichneGridTabelle();
            ZeichneGridWurfanzeige();
        }

        public void CheckElimination(EliminationSpieler spieler) {
            foreach (EliminationSpieler item in EliminationMitspieler.Where(x => x != spieler))
            {
                if (item.Score == spieler.Score) {
                    item.Score = 0;
                }
            }
        }

        private void CheckWurf(int ergebnis)
        {

            EliminationMitspieler[SpielerDran].Score += ergebnis;
            if (EliminationMitspieler[SpielerDran].Score == 301) {
                Wuerfe = 3;
                Anzeige.BtnFertig.Content = "Neu";
            }
            if (EliminationMitspieler[SpielerDran].Score > 301) {
                EliminationMitspieler[SpielerDran].Score -= ergebnis;
                Wuerfe = 3;
            }
            CheckElimination(EliminationMitspieler[SpielerDran]);
        }

        public void MainWindow_OnSpielerNeu(object myObject, EventArgs myArgs)
        {
            MainWindow win = (MainWindow)myObject;
            Mitspieler = win.Mitspieler;
            ErzeugeEliminationSpieler();
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
    }
}
