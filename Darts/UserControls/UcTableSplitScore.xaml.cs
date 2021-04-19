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
    /// Interaktionslogik für UcTableSplitScore.xaml
    /// </summary>
    public partial class UcTableSplitScore : UserControl
    {
        List<SplitScoreSpieler> Mitspieler;
        MainWindow Window;

        public UcTableSplitScore(List<SplitScoreSpieler> mitspieler, MainWindow window)
        {
            Window = window;
            Window.SizeChanged += Window_SizeChanged;
            InitializeComponent();
            Mitspieler = mitspieler;
            ZeichneTabelle();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (Control control in grdMain.Children)
            {
                if (control.GetType() == typeof(Label))
                {
                    control.FontSize = Window.Height / 42;
                }
            }
        }

        public void ZeichneTabelle()
        {
            grdMain.Children.Clear();
            int row = 0;
            foreach (SplitScoreSpieler spieler in Mitspieler)
            {
                int i = 42;

                Label lblName = ErzeugeLabel(spieler.Name + "(" + spieler.Siege +")", row, 0, 3, 1);
                lblName.FontSize = Window.Height / i;
                grdMain.Children.Add(lblName);

                Label lbl15 = ErzeugeLabel(spieler.Score15.ToString(), row, 3, 1, 0);
                lbl15.FontSize = Window.Height / i;
                grdMain.Children.Add(lbl15);

                Label lbl16 = ErzeugeLabel(spieler.Score16.ToString(), row, 4, 1, 0);
                lbl16.FontSize = Window.Height / i;
                grdMain.Children.Add(lbl16);

                Label lblD = ErzeugeLabel(spieler.ScoreD.ToString(), row, 5, 1, 0);
                lblD.FontSize = Window.Height / i;
                grdMain.Children.Add(lblD);

                Label lbl17 = ErzeugeLabel(spieler.Score17.ToString(), row, 6, 1, 0);
                lbl17.FontSize = Window.Height / i;
                grdMain.Children.Add(lbl17);

                Label lbl18 = ErzeugeLabel(spieler.Score18.ToString(), ++row, 0, 1, 0);
                lbl18.FontSize = Window.Height / i;
                grdMain.Children.Add(lbl18);

                Label lblT = ErzeugeLabel(spieler.ScoreT.ToString(), row, 1, 1, 0);
                lblT.FontSize = Window.Height / i;
                grdMain.Children.Add(lblT);

                Label lbl19 = ErzeugeLabel(spieler.Score19.ToString(), row, 2, 1, 0);
                lbl19.FontSize = Window.Height / i;
                grdMain.Children.Add(lbl19);

                Label lbl20 = ErzeugeLabel(spieler.Score20.ToString(), row, 3, 1, 0);
                lbl20.FontSize = Window.Height / i;
                grdMain.Children.Add(lbl20);

                Label lblB = ErzeugeLabel(spieler.ScoreB.ToString(), row, 4, 1, 0);
                lblB.FontSize = Window.Height / i;
                grdMain.Children.Add(lblB);

                Label lblScore = ErzeugeLabel(spieler.Score.ToString(), row, 5, 2, 2);
                lblScore.FontSize = Window.Height / i;
                grdMain.Children.Add(lblScore);
                ++row;
            }
        }

        /// <summary>
        /// art = 0 --> Normal
        /// art = 1 --> Fett links
        /// art = 2 --> Fett rechts
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        private Label ErzeugeLabel(string content, int row, int col, int colspan, int art) {
            Label lbl = new Label();
            lbl.Content = content;
            lbl.VerticalAlignment = VerticalAlignment.Top;
            lbl.HorizontalAlignment = HorizontalAlignment.Center;

            if (art == 1) {
                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                lbl.FontWeight = FontWeights.Bold;
            }

            if (art == 2) {
                lbl.FontWeight = FontWeights.Bold;
            }

            lbl.FontSize = 15;
            Grid.SetRow(lbl, row);
            Grid.SetColumn(lbl, col);
            Grid.SetColumnSpan(lbl, colspan);
            return lbl;
        }
        
    }
}
