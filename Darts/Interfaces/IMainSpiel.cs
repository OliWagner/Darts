using Darts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Interfaces
{
    interface IMainSpiel
    {
        //Events
        void Dartscheibe_MouseDoubleClick(object sender, MouseButtonEventArgs e);
        void Mainwindow_OnSpielWechsel(object myObject, EventArgs myArgs);
        void MainWindow_OnSpielerNeu(object myObject, EventArgs myArgs);
        void AnzeigeBtnFertig_Click(object sender, System.Windows.RoutedEventArgs e);

        //Methoden
        void NextRunde();
        void NextSpieler();
        void ZeichneGridTabelle();
        void ZeichneGridWurfanzeige();
    }
}
