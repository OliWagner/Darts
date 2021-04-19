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
    /// Interaktionslogik für UcScheibe.xaml
    /// </summary>
    public partial class UcScheibe : UserControl
    {
        public UcScheibe()
        {
            InitializeComponent();
            BtnBack.Visibility = Visibility.Hidden;
        }

        public void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Wird im Spiel behandelt
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label _sender = (Label)sender;
            LblScoreOneDart.Content = _sender.Tag.ToString();
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            LblScoreOneDart.Content = "";
        }

        public void SetCricket() {
            foreach (Control item in grdMain.Children)
            {
                if (item.GetType() == typeof(Label)) {
                    if (!item.Name.Equals("")) {
                        item.IsEnabled = false;
                    }
                }
            }
        }

        public void UnsetCricket()
        {
            foreach (Control item in grdMain.Children)
            {
                if (item.GetType() == typeof(Label))
                {
                    if (!item.Name.Equals(""))
                    {
                        item.IsEnabled = true;
                    }
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            //Wird im Spiel behandelt
        }
    }
}
