using Fonákolós.Models;
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

namespace Fonákolós.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();

            NewGame();
        }

        private Square[,] _board { get; set; }
        private bool _lightPlayerTurn { get; set; }
        private bool _gameEnded { get; set; }

        private void NewGame()
        {
            _board = new Square[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _board[i, j] = Square.EMPTY;
                }
            }
            _board[3, 3] = Square.WHITE;
            _board[3, 4] = Square.BLACK;
            _board[4, 3] = Square.BLACK;
            _board[4, 4] = Square.WHITE;

            _lightPlayerTurn = true;
            _gameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            if (_lightPlayerTurn)
            {
                _board[row, column] = Square.WHITE;
                button.Background = Brushes.White;
            }
            else
            {
                _board[row, column] = Square.BLACK;
                button.Background = Brushes.Black;
            }

            _lightPlayerTurn ^= true;
        }

    }
}
