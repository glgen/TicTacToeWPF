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

namespace TicTacToeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game Game;

        public MainWindow()
        {
            InitializeComponent();
            Game = new Game(this);
        }

        public void SetPlayerLabel(string Symbol)
        {
            CurrentPlayerLabel.Content = $"Ходит {Symbol}";
        }

        public void Win(string Symbol)
        {
            MessageBox.Show($"Побеждает {Symbol}");
        }

        public void GameOver()
        {
            MessageBox.Show("Ничья");
        }

        private void Step(object sender, RoutedEventArgs e)
        {
            Button CellButton = (Button)sender;
            string Symbol = Game.GetSymbol();
            CellButton.Content = Symbol;
            CellButton.IsHitTestVisible = false;

            int xpos = Grid.GetColumn(CellButton);
            int ypos = Grid.GetRow(CellButton);

            Game.Step(xpos,ypos);
        }

        public void Reset()
        {
            SetPlayerLabel("X");

            foreach (Button CellButton in ButtonsGrid.Children)
            {
                CellButton.Content = "";
                CellButton.IsHitTestVisible = true;
            }
        }
    }
}
