using Fonákolós.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private bool _lightPlayerTurn;
        public int _lightPlayerScore;
        public int _darkPlayerScore;

        public int LightPlayerScore
        {
            get { return _lightPlayerScore; }
            set
            {
                _lightPlayerScore = value;
                tbLightPlayerScore.Text = _lightPlayerScore.ToString();
            }
        }

        public int DarkPlayerScore
        {
            get { return _darkPlayerScore; }
            set
            {
                _darkPlayerScore = value;
                tbDarkPlayerScore.Text = _darkPlayerScore.ToString();
            }
        }

        //beállítja a játék alaphelyzetét
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
            ChangeSquare(3, 3, true);
            ChangeSquare(4, 4, true);
            ChangeSquare(3, 4, false);
            ChangeSquare(4, 3, false);
            LightPlayerScore = 2;
            DarkPlayerScore = 2;

            _lightPlayerTurn = true;
        }

        //gombokra kattintás kezelése
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var validSquares = CalculateValidSquares();
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            if (validSquares.Any(t => t.Item1 == row && t.Item2 == column))
            {
                ChangeSquare(row, column, _lightPlayerTurn);

                var surroundedSquares = CalculateSurroundedSquares(row, column);
                foreach (var t in surroundedSquares)
                {
                    ChangeSquare(t.Item1, t.Item2, _lightPlayerTurn);
                }

                if (_lightPlayerTurn)
                {
                    LightPlayerScore += surroundedSquares.Count + 1;
                    DarkPlayerScore -= surroundedSquares.Count;
                }
                else
                {
                    LightPlayerScore -= surroundedSquares.Count;
                    DarkPlayerScore += surroundedSquares.Count + 1;
                }

                _lightPlayerTurn ^= true;
            }
        }

        //megváltoztatja a tábla adott értékét, és átszínezi az annak megfelelő gombot a UI-on, az éppen lépő játékos színére
        private void ChangeSquare(int row, int column, bool lightPlayerTurn)
        {
            if (lightPlayerTurn)
            {
                _board[row, column] = Square.WHITE;
                Container.Children.Cast<Button>().First(btn => Grid.GetColumn(btn) == column && Grid.GetRow(btn) == row).Background = Brushes.White;
            }
            else
            {
                _board[row, column] = Square.BLACK;
                Container.Children.Cast<Button>().First(btn => Grid.GetColumn(btn) == column && Grid.GetRow(btn) == row).Background = Brushes.Black;
            }
        }

        //az érvényes mezőket számolja ki, és adja vissza egy tuple halmazban, ahol a tuple első eleme a mező sor, a második a mező oszlop koordinátája
        private HashSet<Tuple<int, int>> CalculateValidSquares()
        {
            HashSet<Tuple<int, int>> res = new HashSet<Tuple<int, int>>();

            var color = _lightPlayerTurn ? Square.WHITE : Square.BLACK;
            var oppositeColor = _lightPlayerTurn ? Square.BLACK : Square.WHITE;

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    //jobbra
                    if (c != 7)
                    {
                        if (_board[r, c] == Square.EMPTY && _board[r, c + 1] == oppositeColor)
                        {
                            for (int i = 1; i < 8 - c; i++)
                            {
                                if (_board[r, c + i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r, c + i] == color)
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
                            for (int i = 1; i < (c + 1); i++)
                            {
                                if (_board[r, c - i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r, c - i] == color)
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
                            for (int i = 1; i < (r + 1); i++)
                            {
                                if (_board[r - i, c] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r - i, c] == color)
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
                        if (_board[r, c] == Square.EMPTY && _board[r + 1, c] == oppositeColor)
                        {
                            for (int i = 1; i < (8 - r); i++)
                            {
                                if (_board[r + i, c] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r + i, c] == color)
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
                        if (_board[r, c] == Square.EMPTY && _board[r - 1, c + 1] == oppositeColor)
                        {
                            for (int i = 1; i < Math.Min(r + 1, 8 - c); i++)
                            {
                                if (_board[r - i, c + i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r - i, c + i] == color)
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
                        if (_board[r, c] == Square.EMPTY && _board[r - 1, c - 1] == oppositeColor)
                        {
                            for (int i = 1; i < Math.Min(r + 1, c + 1); i++)
                            {
                                if (_board[r - i, c - i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r - i, c - i] == color)
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
                        if (_board[r, c] == Square.EMPTY && _board[r + 1, c - 1] == oppositeColor)
                        {
                            for (int i = 1; i < Math.Min(8 - r, c + 1); i++)
                            {
                                if (_board[r+i, c-i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r + i, c - i] == color)
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
                        if (_board[r, c] == Square.EMPTY && _board[r + 1, c + 1] == oppositeColor)
                        {
                            for (int i = 1; i < Math.Min(8 - r, 8 - c); i++)
                            {
                                if (_board[r + i, c + i] == Square.EMPTY)
                                {
                                    break;
                                }
                                else if (_board[r + i, c + i] == color)
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

        //a körbevett mezőket számolja ki, és adja vissza egy tuple halmazban, ahol a tuple első eleme a mező sor, a második a mező oszlop koordinátája
        private HashSet<Tuple<int, int>> CalculateSurroundedSquares(int row, int column)
        {
            HashSet<Tuple<int, int>> res = new HashSet<Tuple<int, int>>();
            HashSet<Tuple<int, int>> temp = new HashSet<Tuple<int, int>>();

            var color = _lightPlayerTurn ? Square.WHITE : Square.BLACK;
            var oppositeColor = _lightPlayerTurn ? Square.BLACK : Square.WHITE;

            //jobbra
            for (int i = 1; i < 8 - column; i++)
            {
                if (_board[row, column + i] == oppositeColor)
                {
                    temp.Add(new Tuple<int, int>(row, column + i));
                }
                else if (_board[row, column + i] == color)
                {
                    res.UnionWith(temp);
                    temp.Clear();
                    break;
                }
                else
                {
                    temp.Clear();
                    break;
                }
            }
            temp.Clear();

            //balra
            for (int i = 1; i < (column + 1); i++)
            {
                if (_board[row, column - i] == oppositeColor)
                {
                    temp.Add(new Tuple<int, int>(row, column-i));
                }
                else if (_board[row, column - i] == color)
                {
                    res.UnionWith(temp);
                    temp.Clear();
                    break;
                }
                else
                {
                    temp.Clear();
                    break;
                }
            }
            temp.Clear();


            //fel
            for (int i = 1; i < (row + 1); i++)
            {
                if (_board[row - i, column] == oppositeColor)
                {
                    temp.Add(new Tuple<int, int>(row - i, column));
                }
                else if (_board[row - i, column] == color)
                {
                    res.UnionWith(temp);
                    temp.Clear();
                    break;
                }
                else
                {
                    temp.Clear();
                    break;
                }
            }
            temp.Clear();

            //le
            for (int i = 1; i < (8 - row); i++)
            {
                if (_board[row + i, column] == oppositeColor)
                {
                    temp.Add(new Tuple<int, int>(row + i, column));
                }
                else if (_board[row + i, column] == color)
                {
                    res.UnionWith(temp);
                    temp.Clear();
                    break;
                }
                else
                {
                    temp.Clear();
                    break;
                }
            }
            temp.Clear();

            //felső jobb átló felé
            for (int i = 1; i < Math.Min(row + 1, 8 - column); i++)
            {
                if (_board[row - i, column + i] == oppositeColor)
                {
                    temp.Add(new Tuple<int, int>(row - i, column + i));
                }
                else if (_board[row - i, column + i] == color)
                {
                    res.UnionWith(temp);
                    temp.Clear();
                    break;
                }
                else
                {
                    temp.Clear();
                    break;
                }
            }
            temp.Clear();

            //felső bal átló felé
            for (int i = 1; i < Math.Min(row + 1, column + 1); i++)
            {
                if (_board[row - i, column - i] == oppositeColor)
                {
                    temp.Add(new Tuple<int, int>(row-i, column-i));
                }
                else if (_board[row - i, column - i] == color)
                {
                    res.UnionWith(temp);
                    temp.Clear();
                    break;
                }
                else
                {
                    temp.Clear();
                    break;
                }
            }
            temp.Clear();

            //lefelé bal átló felé
            for (int i = 1; i < Math.Min(8 - row, column + 1); i++)
            {
                if (_board[row + i, column - i] == oppositeColor)
                {
                    temp.Add(new Tuple<int, int>(row + i, column - i));
                }
                else if (_board[row + i, column - i] == color)
                {
                    res.UnionWith(temp);
                    temp.Clear();
                    break;
                }
                else
                {
                    temp.Clear();
                    break;
                }
            }
            temp.Clear();

            //lefelé jobb átló felé
            for (int i = 1; i < Math.Min(8 - row, 8 - column); i++)
            {
                if (_board[row + i, column + i] == oppositeColor)
                {
                    temp.Add(new Tuple<int, int>(row + i, column + i));
                }
                else if (_board[row + i, column + i] == color)
                {
                    res.UnionWith(temp);
                    temp.Clear();
                    break;
                }
                else
                {
                    temp.Clear();
                    break;
                }
            }
            return res;
        }
    }
}
