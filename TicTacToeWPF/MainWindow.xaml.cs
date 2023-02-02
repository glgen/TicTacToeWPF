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
        private int CurrentPlayer = 1;
        private int[,] CellsData = new int[3, 3];

        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetSymbol() {
            if (CurrentPlayer == 1)
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }

        private bool IsWin(int x, int y) {
            return ((CellsData[x, 0] == CurrentPlayer && CellsData[x, 1] == CurrentPlayer && CellsData[x, 2] == CurrentPlayer) ||
            (CellsData[0, y] == CurrentPlayer && CellsData[1, y] == CurrentPlayer && CellsData[2, y] == CurrentPlayer) ||
            (CellsData[0, 0] == CurrentPlayer && CellsData[1, 1] == CurrentPlayer && CellsData[2, 2] == CurrentPlayer) ||
            (CellsData[0, 2] == CurrentPlayer && CellsData[1, 1] == CurrentPlayer && CellsData[2, 0] == CurrentPlayer));
        }

        private bool IsGameOver() {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (CellsData[x, y] == 0)
                    {
                        return false;
}
                }
            }
            return true;
        }

        private void Step(object sender, RoutedEventArgs e)
        {
            Button CellButton = (Button)sender;
            string Symbol = GetSymbol();
            CellButton.Content = Symbol;
            CellButton.IsHitTestVisible = false;

            int xpos = Grid.GetColumn(CellButton);
            int ypos = Grid.GetRow(CellButton);

            CellsData[xpos, ypos] = CurrentPlayer;

            if (IsWin(xpos, ypos))
            {
                MessageBox.Show($"Побеждает {Symbol}");
                Reset();
            }
            else if (IsGameOver())
            {
                MessageBox.Show("Ничья");
                Reset();
            }
            else
            {
                CurrentPlayer = 3 - CurrentPlayer;
                CurrentPlayerLabel.Content = $"Ходит {GetSymbol()}";
            }
        }

        private void Reset()
        {
            CurrentPlayer = 1;
            CurrentPlayerLabel.Content = "Ходит X";

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    CellsData[x, y] = 0;
                }
            }

            foreach (Button CellButton in ButtonsGrid.Children)
            {
                CellButton.Content = "";
                CellButton.IsHitTestVisible = true;
            }
        }
    }
}
