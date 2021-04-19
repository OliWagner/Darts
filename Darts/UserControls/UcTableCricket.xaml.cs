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
    /// Interaktionslogik für UcTableCricket.xaml
    /// </summary>
    public partial class UcTableCricket : UserControl
    {
        List<CricketSpieler> Mitspieler = new List<CricketSpieler>();
        MainWindow Window;

        public UcTableCricket()
        {
            InitializeComponent();
        }

        public UcTableCricket(List<CricketSpieler> mitspieler, MainWindow win)
        {
            InitializeComponent();
            Window = win;
            Window.SizeChanged += Window_SizeChanged;
            Mitspieler = mitspieler;
            ZeichneGrid();

            int i = 42;
            Lbl15.FontSize = Window.Height / i;
            Lbl16.FontSize = Window.Height / i;
            Lbl17.FontSize = Window.Height / i;
            Lbl18.FontSize = Window.Height / i;
            Lbl19.FontSize = Window.Height / i;
            Lbl20.FontSize = Window.Height / i;
            LblB.FontSize = Window.Height / i;
            LblSpieler.FontSize = Window.Height / i;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int i = 42;
            Lbl15.FontSize = Window.Height / i;
            Lbl16.FontSize = Window.Height / i;
            Lbl17.FontSize = Window.Height / i;
            Lbl18.FontSize = Window.Height / i;
            Lbl19.FontSize = Window.Height / i;
            Lbl20.FontSize = Window.Height / i;
            LblB.FontSize = Window.Height / i;
            LblSpieler.FontSize = Window.Height / i;
            foreach (Control control in grdMain.Children)
            {
                if (control.GetType() == typeof(Label))
                {
                    control.FontSize = Window.Height / i;
                }
            }
        }

        public void ZeichneGrid() {
            int rowCounter = 0;
            int i = 42;
            foreach (CricketSpieler spieler in Mitspieler) {
                Label lblName = new Label();
                lblName.VerticalAlignment = VerticalAlignment.Center;
                lblName.HorizontalAlignment = HorizontalAlignment.Center;
                lblName.FontSize = Window.Height / i;
                lblName.Content = spieler.Name;
                Grid.SetRow(lblName, rowCounter);
                Grid.SetColumn(lblName, 0);
                grdMain.Children.Add(lblName);

                Label lblScore = new Label();
                lblScore.VerticalAlignment = VerticalAlignment.Center;
                lblScore.HorizontalAlignment = HorizontalAlignment.Center;
                lblScore.FontSize = Window.Height / i; ;
                lblScore.Content = spieler.Score;
                Grid.SetRow(lblScore, rowCounter);
                Grid.SetColumn(lblScore, 1);
                grdMain.Children.Add(lblScore);

                Label lbl15 = new Label();
                string path = "pack://application:,,,/Images/Cricket" + spieler.Wuerfe15 + ".png";
                var image = new BitmapImage(new Uri(path));
                lbl15.Background = new ImageBrush(image);
                lbl15.Margin = new Thickness(5);
                Grid.SetRow(lbl15, rowCounter);
                Grid.SetColumn(lbl15, 2);
                grdMain.Children.Add(lbl15);

                Label lbl16 = new Label();
                path = "pack://application:,,,/Images/Cricket" + spieler.Wuerfe16 + ".png";
                image = new BitmapImage(new Uri(path));
                lbl16.Background = new ImageBrush(image);
                lbl16.Margin = new Thickness(5);
                Grid.SetRow(lbl16, rowCounter);
                Grid.SetColumn(lbl16, 3);
                grdMain.Children.Add(lbl16);

                Label lbl17 = new Label();
                path = "pack://application:,,,/Images/Cricket" + spieler.Wuerfe17 + ".png";
                image = new BitmapImage(new Uri(path));
                lbl17.Background = new ImageBrush(image);
                lbl17.Margin = new Thickness(5);
                Grid.SetRow(lbl17, rowCounter);
                Grid.SetColumn(lbl17, 4);
                grdMain.Children.Add(lbl17);

                Label lbl18 = new Label();
                path = "pack://application:,,,/Images/Cricket" + spieler.Wuerfe18 + ".png";
                image = new BitmapImage(new Uri(path));
                lbl18.Background = new ImageBrush(image);
                lbl18.Margin = new Thickness(5);
                Grid.SetRow(lbl18, rowCounter);
                Grid.SetColumn(lbl18, 5);
                grdMain.Children.Add(lbl18);

                Label lbl19 = new Label();
                path = "pack://application:,,,/Images/Cricket" + spieler.Wuerfe19 + ".png";
                image = new BitmapImage(new Uri(path));
                lbl19.Background = new ImageBrush(image);
                lbl19.Margin = new Thickness(5);
                Grid.SetRow(lbl19, rowCounter);
                Grid.SetColumn(lbl19, 6);
                grdMain.Children.Add(lbl19);

                Label lbl20 = new Label();
                path = "pack://application:,,,/Images/Cricket" + spieler.Wuerfe20 + ".png";
                image = new BitmapImage(new Uri(path));
                lbl20.Background = new ImageBrush(image);
                lbl20.Margin = new Thickness(5);
                Grid.SetRow(lbl20, rowCounter);
                Grid.SetColumn(lbl20, 7);
                grdMain.Children.Add(lbl20);

                Label lblB = new Label();
                path = "pack://application:,,,/Images/Cricket" + spieler.WuerfeB + ".png";
                image = new BitmapImage(new Uri(path));
                lblB.Background = new ImageBrush(image);
                lblB.Margin = new Thickness(5);
                Grid.SetRow(lblB, rowCounter);
                Grid.SetColumn(lblB, 8);
                grdMain.Children.Add(lblB);

                rowCounter++;
            }
        }
    }
}
