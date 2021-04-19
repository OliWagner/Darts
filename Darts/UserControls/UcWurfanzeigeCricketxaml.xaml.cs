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
    /// Interaktionslogik für UcWurfanzeigeCricketxaml.xaml
    /// </summary>
    public partial class UcWurfanzeigeCricketxaml : UserControl
    {
        MainWindow Window;
        public UcWurfanzeigeCricketxaml(MainWindow win)
        {
            InitializeComponent();
            
            Window = win;
            Window.SizeChanged += Window_SizeChanged;
            LblSpielerName.FontSize = Window.Height / 28;
            BtnFertig.FontSize = Window.Height / 30;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LblSpielerName.FontSize = Window.Height / 28;
            BtnFertig.FontSize = Window.Height / 30;
        }
    }
}
