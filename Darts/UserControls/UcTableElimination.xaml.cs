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
    /// Interaktionslogik für UcTableElimination.xaml
    /// </summary>
    public partial class UcTableElimination : UserControl
    {
        List<EliminationSpieler> Mitspieler;
        MainWindow Window;

        public UcTableElimination(List<EliminationSpieler> mitspieler, int runde, MainWindow win)
        {
            InitializeComponent();
            Window = win;
            Window.SizeChanged += Window_SizeChanged;
            LblRunde.Content = runde;
            Mitspieler = mitspieler;
            ZeichneTabelle();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LblRunde.FontSize = Window.Height / 25;
            LblScore.FontSize = Window.Height / 25;
            LblSpieler.FontSize = Window.Height / 25;

            foreach (Control control in grdMain.Children)
            {
                if (control.GetType() == typeof(Label))
                {
                    control.FontSize = Window.Height / 25;
                }
            }
        }

        public void ZeichneTabelle()
        {
            
            grdMain.Children.Clear();
            int rowCounter = 0;
            foreach (EliminationSpieler spieler in Mitspieler)
            {
                Label lblName = new Label();
                lblName.FontSize = 25;
                lblName.HorizontalAlignment = HorizontalAlignment.Center;
                lblName.VerticalAlignment = VerticalAlignment.Center;
                lblName.Content = spieler.Name;
                Grid.SetRow(lblName, rowCounter);
                Grid.SetColumn(lblName, 0);
                grdMain.Children.Add(lblName);

                Label lblScore = new Label();
                lblScore.FontSize = 25;
                lblScore.HorizontalAlignment = HorizontalAlignment.Center;
                lblScore.VerticalAlignment = VerticalAlignment.Center;
                lblScore.Content = spieler.Score;
                Grid.SetRow(lblScore, rowCounter);
                Grid.SetColumn(lblScore, 1);
                grdMain.Children.Add(lblScore);

                
                rowCounter++;
            }
        }
    }
}
