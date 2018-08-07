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
using System.Windows.Shapes;

namespace KolkoKrzyzyk
{
    /// <summary>
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        int[,] tab = new int[3,3];
        int player = new int();

        public Game()
        {
            InitializeComponent();
            Array.Clear(tab, 0, tab.Length);
            player = 0;
        }

        public bool End_Game()  //Checks if game is ending
        {
            for (int i = 0; i < 3; i++)
            {
                if (tab[i,0] == tab[i,1] && tab[i,1] == tab[i,2] && tab[i,0] != 0)
                {
                    return true;
                }
                else if(tab[0,i] == tab[1,i] && tab[1,i] == tab[2,i] && tab[0,i] != 0)
                {
                    return true;
                }
            }
            
            if(tab[0,0] == tab[1,1] && tab[1,1] == tab[2,2] && tab[0,0] != 0)
            {
                return true;
            }
            else if(tab[0,2] == tab[1,1] && tab[1,1] == tab[2,0] && tab[0,2] != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Result()
        {
            string messageBoxText = "The winner is Player" + player + " Do you want play again?";
            string title = "Result";
            MessageBoxResult result = MessageBox.Show(messageBoxText, title, MessageBoxButton.YesNo, MessageBoxImage.None);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Game wnd = new Game();
                    wnd.Show();
                    this.Close();
                    break;

                case MessageBoxResult.No:
                    MainWindow wnd2 = new MainWindow();
                    wnd2.Show();
                    this.Close();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as Button).Tag == "0")
            {
                int column, row;
                row = Grid.GetRow(sender as Button);
                column = Grid.GetColumn(sender as Button);
                (sender as Button).Tag = "1";

                if (player == 0 || player == 1)
                {
                    tab[row, column] = 1;
                    (sender as Button).Content = "X";
                    (sender as Button).Foreground = Brushes.MediumBlue;
                    if (End_Game())
                    {
                        Result();
                    }
                    else
                    {
                        player = 2;
                    }
                }
                else
                {
                    tab[row, column] = 2;
                    (sender as Button).Content = "O";
                    (sender as Button).Foreground = Brushes.Firebrick;
                    if (End_Game())
                    {
                        Result();
                    }
                    else
                    {
                        player = 1;
                    }
                }
            }
        }
    }
}
