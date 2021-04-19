using Darts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Darts.UserControls
{
    /// <summary>
    /// Interaktionslogik für UcTableX01.xaml
    /// </summary>
    public partial class UcTableX01 : UserControl
    {
        List<Spieler> Mitspieler;
        MainWindow Window;

        public UcTableX01()
        {
            InitializeComponent();
        }

        public UcTableX01(List<Spieler> mitspieler, MainWindow window)
        {
            InitializeComponent();
            Window = window;
            Window.SizeChanged += Window_SizeChanged;
            Mitspieler = mitspieler;
            ZeichneTabelle();
            LblScore.FontSize = Window.Height / 25;
            LblSpieler.FontSize = Window.Height / 25;
            LblWins.FontSize = Window.Height / 25;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LblScore.FontSize = Window.Height / 25;
            LblSpieler.FontSize = Window.Height / 25;
            LblWins.FontSize = Window.Height / 25;
            foreach (Control control in grdMain.Children) {
                if (control.GetType() == typeof(Label)) {
                    control.FontSize = Window.Height / 25;
                }
            }
        }

        public void ZeichneTabelle() {
            grdMain.Children.Clear();
            int rowCounter = 0;
            foreach (Spieler spieler in Mitspieler)
            {
                    Label lblName = new Label();
                    lblName.FontSize = Window.Height / 25;
                    lblName.HorizontalAlignment = HorizontalAlignment.Center;
                    lblName.VerticalAlignment = VerticalAlignment.Center;
                    lblName.Content = spieler.Name;
                    Grid.SetRow(lblName, rowCounter);
                    Grid.SetColumn(lblName, 0);
                    grdMain.Children.Add(lblName);

                    Label lblScore = new Label();
                    lblScore.FontSize = Window.Height / 25;
                    lblScore.HorizontalAlignment = HorizontalAlignment.Center;
                    lblScore.VerticalAlignment = VerticalAlignment.Center;
                    lblScore.Content = spieler.Score;
                    Grid.SetRow(lblScore, rowCounter);
                    Grid.SetColumn(lblScore, 1);
                    grdMain.Children.Add(lblScore);

                    Label lblSiege = new Label();
                    lblSiege.FontSize = Window.Height / 25;
                    lblSiege.HorizontalAlignment = HorizontalAlignment.Center;
                    lblSiege.VerticalAlignment = VerticalAlignment.Center;
                    lblSiege.Content = spieler.Siege;
                    Grid.SetRow(lblSiege, rowCounter);
                    Grid.SetColumn(lblSiege, 2);
                    grdMain.Children.Add(lblSiege);
                    rowCounter++;
            }
        }
    }
}
