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
    /// Interaktionslogik für UcWurfanzeigeElimination.xaml
    /// </summary>
    public partial class UcWurfanzeigeElimination : UserControl
    {
        MainWindow Window;

        private int score = 0;
        public int Score { get {
                return score;
            }
            set {
                score = value;
                LblScore.Content = score;
            }
        }


        public UcWurfanzeigeElimination(string name, int _score, MainWindow win)
        {
            InitializeComponent();
            Window = win;
            Window.SizeChanged += Window_SizeChanged;
            LblName.Content = name;
            Score = _score;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LblName.FontSize = Window.Height / 19;
            LblScore.FontSize = Window.Height / 19;
            BtnFertig.FontSize = Window.Height / 21;
        }

        private void BtnFertig_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
