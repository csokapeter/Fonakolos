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
    public class GameViewModel : ViewModelBase
    {
        private string _lightPlayerName;
        private string _darkPlayerName;
        private GameMode _gameMode;

        public string LightPlayerName 
        { 
            get { return _lightPlayerName; } 
            set { _lightPlayerName = value; }
        }

        public string DarkPlayerName
        {
            get { return _darkPlayerName; }
            set { _darkPlayerName = value; }
        }

        public GameMode GameMode
        {
            get { return _gameMode; }
            set { _gameMode = value; }
        }

        public GameViewModel(string lightPlayerName, GameMode gameMode)
        {
            LightPlayerName = lightPlayerName;
            DarkPlayerName = "COMPUTER";
            GameMode = gameMode;
        }

        public GameViewModel(string lightPlayerName, string darkPlayerName, GameMode gameMode)
        {
            LightPlayerName = lightPlayerName;
            DarkPlayerName = darkPlayerName;
            GameMode = gameMode;
        }
        public GameViewModel(GameMode gameMode)
        {
            GameMode = gameMode;
        }

    }
}
