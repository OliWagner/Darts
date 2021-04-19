using Darts.Classes;
using Darts.Dialoge;
using Darts.Interfaces;
using Darts.Spiele;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Darts
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMainSpiel spiel;

        public List<Spieler> Mitspieler = new List<Spieler>();
        public string BezeichnungAktuellesSpiel { get; set; }

        public delegate void SpielerHinzuHandler(object myObject, EventArgs myArgs);
        public event SpielerHinzuHandler OnSpielerNeu;

        public delegate void SpieleWechselHandler(object myObject, EventArgs myArgs);
        public event SpieleWechselHandler OnSpielWechsel;

        public MainWindow()
        {
            InitializeComponent();
            WinStart start = new WinStart();
            start.ShowDialog();
            Mitspieler = start.Mitspieler;
            SizeChanged += MainWindow_SizeChanged;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DartBoard.LblScoreOneDart.FontSize = Height / 20;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string path = "";
            DartBoard.UnsetCricket();
            OnSpielWechsel?.Invoke(this, new EventArgs());
            MenuItem item = (MenuItem)sender;
            if (item.Tag.ToString().Equals("Close")) {
                Close();
            }

            if (item.Tag.ToString().Equals("101"))
            {
                path = "pack://application:,,,/Images/101.png";
                spiel = new X01(grdWurfanzeige, grdTabelle, Mitspieler, DartBoard, 101, this);
            }

            if (item.Tag.ToString().Equals("301"))
            {
                path = "pack://application:,,,/Images/301.png";
                spiel = new X01(grdWurfanzeige, grdTabelle, Mitspieler, DartBoard, 301, this);
            }

            if (item.Tag.ToString().Equals("501"))
            {
                path = "pack://application:,,,/Images/501.png";
                spiel = new X01(grdWurfanzeige, grdTabelle, Mitspieler, DartBoard, 501, this);
            }

            if (item.Tag.ToString().Equals("701"))
            {
                path = "pack://application:,,,/Images/701.png";
                spiel = new X01(grdWurfanzeige, grdTabelle, Mitspieler, DartBoard, 701, this);
            }

            if (item.Tag.ToString().Equals("901"))
            {
                path = "pack://application:,,,/Images/901.png";
                spiel = new X01(grdWurfanzeige, grdTabelle, Mitspieler, DartBoard, 901, this);
            }

            if (item.Tag.ToString().Equals("Cricket"))
            {
                path = "pack://application:,,,/Images/Cricket.png";

                DartBoard.SetCricket();
                Cricket cricket = new Cricket(grdWurfanzeige, grdTabelle, Mitspieler, DartBoard, this);
            }

            if (item.Tag.ToString().Equals("SplitScore"))
            {
                path = "pack://application:,,,/Images/SplitScore.png";
                SplitScore splitscore = new SplitScore(grdWurfanzeige, grdTabelle, Mitspieler, DartBoard, this);
            }

            if (item.Tag.ToString().Equals("Elimination"))
            {
                path = "pack://application:,,,/Images/Elimination.png";
                Elimination elimination = new Elimination(grdWurfanzeige, grdTabelle, Mitspieler, DartBoard, this);
            }
            var image = new BitmapImage(new Uri(path));
            LblSpielIcon.Background = new ImageBrush(image);
            BtnSpielerPlus.Visibility = Visibility.Visible;
            Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/BgMainscreen.png")));
            DartBoard.Visibility = Visibility.Visible;
        }

        private void BtnSpielerPlus_Click(object sender, RoutedEventArgs e)
        {
            WinStart start = new WinStart(Mitspieler);
            start.ShowDialog();
            Mitspieler = start.Mitspieler;
            OnSpielerNeu(this, new EventArgs());
        }
    }
}
