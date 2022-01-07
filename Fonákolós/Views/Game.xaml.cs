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
            ChangeSquare(3, 3, true, Container.Children.Cast<Button>().Where(btn => Grid.GetColumn(btn) == 3 && Grid.GetRow(btn) == 3).First());
            ChangeSquare(4, 4, true, Container.Children.Cast<Button>().Where(btn => Grid.GetColumn(btn) == 4 && Grid.GetRow(btn) == 4).First());
            ChangeSquare(3, 4, false, Container.Children.Cast<Button>().Where(btn => Grid.GetColumn(btn) == 3 && Grid.GetRow(btn) == 4).First());
            ChangeSquare(4, 3, false, Container.Children.Cast<Button>().Where(btn => Grid.GetColumn(btn) == 4 && Grid.GetRow(btn) == 3).First());

            _lightPlayerTurn = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var validSquares = CalculateValidSquares(_lightPlayerTurn);
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            if (validSquares.Any(t => t.Item1 == row && t.Item2 == column))
            {
                ChangeSquare(row, column, _lightPlayerTurn, button);

                _lightPlayerTurn ^= true;
            }
        }

        private void ChangeSquare(int row, int column, bool lightPlayerTurn, Button button)
        {
            if (lightPlayerTurn)
            {
                _board[row, column] = Square.WHITE;
                button.Background = Brushes.White;
            }
            else
            {
                _board[row, column] = Square.BLACK;
                button.Background = Brushes.Black;
            }
        }

        private HashSet<Tuple<int, int>> CalculateValidSquares(bool lightPlayerTurn)
        {
            HashSet<Tuple<int, int>> res = new HashSet<Tuple<int, int>>();

            var color = lightPlayerTurn ? Square.WHITE : Square.BLACK;
            var oppositeColor = lightPlayerTurn ? Square.BLACK : Square.WHITE;

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    //jobbra
                    if (c != 7)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r, c+1] == oppositeColor)
                        {
                            for (int i = 1; i < 7-c; i++)
                            {
                                if (_board[r, c+i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r, c+i] == color)
                                {
                                    res.Add(new Tuple<int, int>(r, c));
                                    break;
                                }
                            }
                        }
                    }

                    //balra
                    if (c != 0)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r, c-1] == oppositeColor)
                        {
                            for (int i = 1; i < (c+1); i++)
                            {
                                if (_board[r, c-i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r, c-i] == color)
                                {
                                    res.Add(new Tuple<int, int>(r, c));
                                    break;
                                }
                            }
                        }
                    }

                    //fel
                    if (r != 0)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r-1, c] == oppositeColor)
                        {
                            for (int i = 1; i < (r+1); i++)
                            {
                                if (_board[r-i, c] == Square.EMPTY)
                                    break;
                                else if (_board[r-i, c] == color)
                                {
                                    res.Add(new Tuple<int, int>(r, c));
                                    break;
                                }
                            }
                        }
                    }

                    //le
                    if (r != 7)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r+1, c] == oppositeColor)
                        {
                            for (int i = 1; i < (7-r); i++)
                            {
                                if (_board[r+i, c] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r+i, c] == color)
                                {
                                    res.Add(new Tuple<int, int>(r, c));
                                    break;

                                }
                            }
                        }
                    }

                    //felső jobb átló felé
                    if (r != 0 && c != 7)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r-1, c+1] == oppositeColor)
                        {
                            for (int i = 1; i < Math.Min(r+1, 7-c); i++)
                            {
                                if (_board[r-i, c+i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r-i, c+i] == color)
                                {
                                    res.Add(new Tuple<int, int>(r, c));
                                    break;

                                }
                            }
                        }
                    }

                    //felső bal átló felé
                    if (r != 0 && c != 0)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r-1, c-1] == oppositeColor)
                        {
                            for (int i = 1; i < Math.Min(r+1, c+1); i++)
                            {
                                if (_board[r-i, c-i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r-i, c-i] == color)
                                {
                                    res.Add(new Tuple<int, int>(r, c));
                                    break;

                                }
                            }
                        }
                    }

                    //lefelé bal átló felé
                    if (r != 7 && c != 0)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r+1, c-1] == oppositeColor)
                        {
                            for (int i = 1; i < Math.Min(7-r, c+1); i++)
                            {
                                if (_board[r+i, c-i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r+i, c-i] == color)
                                {
                                    res.Add(new Tuple<int, int>(r, c));
                                    break;

                                }
                            }
                        }
                    }

                    //lefelé jobb átló felé
                    if (r != 7 && c != 7)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r+1, c+1] == oppositeColor)
                        {
                            for (int i = 1; i < Math.Min(7-r, 7-c); i++)
                            {
                                if (_board[r+i, c+i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r+i, c+i] == color)
                                {
                                    res.Add(new Tuple<int, int>(r, c));
                                    break;

                                }
                            }
                        }
                    }
                }
            }
            return res;
        }
    }
}
