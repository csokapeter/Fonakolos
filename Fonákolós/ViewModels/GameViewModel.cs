using Fonákolós.Models;
using Fonákolós.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fonákolós.ViewModels
{
    class GameViewModel : ViewModelBase
    {
        private string _lightPlayerName;
        private string _darkPlayerName;
        private GameMode _gameMode;

        public GameViewModel(string lightPlayerName, GameMode gameMode)
        {
            _lightPlayerName = lightPlayerName;
            _darkPlayerName = "COMPUTER";
            _gameMode = gameMode;
        }

        public GameViewModel(string lightPlayerName, string darkPlayerName, GameMode gameMode)
        {
            _lightPlayerName = lightPlayerName;
            _darkPlayerName = darkPlayerName;
            _gameMode = gameMode;
        }

    }
}
