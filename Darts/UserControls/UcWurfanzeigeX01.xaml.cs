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
    /// Interaktionslogik für UcWurfanzeigeX01.xaml
    /// </summary>
    public partial class UcWurfanzeigeX01 : UserControl
    {
        MainWindow Window;

        public UcWurfanzeigeX01()
        {
            InitializeComponent();
        }

        public UcWurfanzeigeX01(string name, MainWindow window)
        {
            InitializeComponent();
            Window = window;
            Window.SizeChanged += Window_SizeChanged;
            Score = 0;
            Spielername = name;
            LblScore.Content = 0;

            Lbl1.FontSize = Window.Height / 20;
            Lbl2.FontSize = Window.Height / 20;
            Lbl3.FontSize = Window.Height / 20;
            LblNameSpieler.FontSize = Window.Height / 22;
            LblScore.FontSize = Window.Height / 20;
            LblScore1.FontSize = Window.Height / 20;
            LblScore2.FontSize = Window.Height / 20;
            LblScore3.FontSize = Window.Height / 20;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Lbl1.FontSize = Window.Height / 20;
            Lbl2.FontSize = Window.Height / 20;
            Lbl3.FontSize = Window.Height / 20;
            LblNameSpieler.FontSize = Window.Height / 22;
            LblScore.FontSize = Window.Height / 20;
            LblScore1.FontSize = Window.Height / 20;
            LblScore2.FontSize = Window.Height / 20;
            LblScore3.FontSize = Window.Height / 20;
        }

        private string _spielername;
        public string Spielername
        {
            get
            {
                return _spielername;
            }
            set
            {
                _spielername = value;
                LblNameSpieler.Content = value;
            }
        }

        private string _score1 = null;
        public string Score1
        {
            get { return _score1; }
            set
            {
                _score1 = value;
                LblScore1.Content = value;
                LblScore.Content = value;
            }
        }

        private string _score2 = null;
        public string Score2
        {
            get { return _score2; }
            set
            {
                _score2 = value;
                LblScore2.Content = value;
                if (value != null) {
                    LblScore.Content = Int32.Parse(value) + Int32.Parse(Score1);
                }
                
            }
        }

        private string _score3 = null;
        public string Score3
        {
            get { return _score3; }
            set
            {
                _score3 = value;
                LblScore3.Content = value;
                if (value != null)
                {
                    LblScore.Content = Int32.Parse(value) + Int32.Parse(Score1) + Int32.Parse(Score2);
                    BtnFertig.Visibility = Visibility.Visible;
                }
            }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                LblScore.Content = value;
            }
        }

        

        private void BtnFertig_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
