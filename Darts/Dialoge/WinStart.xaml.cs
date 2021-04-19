using Darts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Darts.Dialoge
{
    /// <summary>
    /// Interaktionslogik für WinStart.xaml
    /// </summary>
    public partial class WinStart : Window
    {
        #region CloseButton
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        #endregion


        public List<Spieler> Mitspieler = new List<Spieler>();
        private int y = 0;

        public WinStart()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        public WinStart(List<Spieler> liste) {
            InitializeComponent();
            Loaded += Window_Loaded;
            Mitspieler = liste;
            ZeichneGrid();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (btnClose != null)
            {
                btnClose.Visibility = Mitspieler.Count > 0 ? Visibility.Visible : Visibility.Hidden;
            }
            e.CanExecute = true;
            if (txtName.Text.Length < 2 || Mitspieler.Where(x => x.Name.Equals(txtName.Text)).Any() || Mitspieler.Count() == 8)
            {
                if (Mitspieler.Count() == 8)
                {
                    btnName.Content = "8 MAX!!!";
                    btnName.IsEnabled = false;
                    txtName.IsEnabled = false;
                }
                else {
                    btnName.Content = "Hinzu";
                    btnName.IsEnabled = true;
                    txtName.IsEnabled = true;
                }
                e.CanExecute = false;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void BtnName_Click(object sender, RoutedEventArgs e)
        {
            Mitspieler.Add(new Spieler(txtName.Text));
            txtName.Text = "";
            ZeichneGrid();
        }

        private void ZeichneGrid()
        {
            grdSpieler.Children.Clear();
            y = 0;
            foreach (Spieler spieler in Mitspieler)
            {
                Label label = new Label();
                label.Margin = new Thickness(0, y, 0, 0);
                label.Content = spieler.Name + " (" + spieler.Siege + ")";
                label.Foreground = new SolidColorBrush(Colors.Green);
                label.FontSize = 20;
                grdSpieler.Children.Add(label);


                //Label labelSleep = new Label();
                //labelSleep.Margin = new Thickness(120, y, 0, 0);
                //labelSleep.Content = "O";
                //labelSleep.Foreground = spieler.IsActive ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
                //labelSleep.Tag = spieler.Name;
                //labelSleep.MouseDoubleClick += LabelSleep_MouseDoubleClick;
                //labelSleep.FontSize = 20;
                //grdSpieler.Children.Add(labelSleep);

                Label labelDelete = new Label();
                labelDelete.Margin = new Thickness(150, y, 0, 0);
                labelDelete.Content = "X";
                labelDelete.Tag = spieler.Name;
                labelDelete.MouseDoubleClick += LabelDelete_MouseDoubleClick;
                labelDelete.FontSize = 20;
                grdSpieler.Children.Add(labelDelete);


                y = y + 35;
            }
        }

        private void LabelDelete_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label LblDelete = (Label)sender;
            Spieler sp = (Spieler)Mitspieler.Where(x => x.Name.Equals(LblDelete.Tag.ToString())).FirstOrDefault();
            Mitspieler.Remove(sp);
            ZeichneGrid();
        }

        

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
