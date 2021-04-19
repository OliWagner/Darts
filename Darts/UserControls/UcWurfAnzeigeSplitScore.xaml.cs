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
    /// Interaktionslogik für UcWurfAnzeigeSplitScore.xaml
    /// </summary>
    public partial class UcWurfAnzeigeSplitScore : UserControl
    {
        MainWindow Window;
        private int score = 0;
        public int Score { get { return score;} set {
                score += value;
                LblScore.Content = score;
            } }

        public UcWurfAnzeigeSplitScore(MainWindow win)
        {
            InitializeComponent();
            Window = win;
            Window.SizeChanged += Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LblName.FontSize = Window.Height / 22;
            LblScore.FontSize = Window.Height / 22;
            LblZiel.FontSize = Window.Height / 22;
            BtnFertig.FontSize = Window.Height / 24;
        }

        private void BtnFertig_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
