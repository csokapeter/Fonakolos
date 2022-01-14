using Fonákolós.Commands;
using Fonákolós.Models;
using Fonákolós.Stores;
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
            get => _lightPlayerName;
            set
            {
                _lightPlayerName = value;
            }
        }

        public string DarkPlayerName
        {
            get => _darkPlayerName;
            set
            {
                _darkPlayerName = value;
            }
        }

        public GameMode GameMode
        {
            get => _gameMode;
            set 
            { 
                _gameMode = value; 
            }
        }

        public ICommand NavigateToTitleScreenCommand { get; }

        public ICommand NavigateToScoreBoard { get; }

        public GameViewModel(NavigationStore navigationStore, string lightPlayerName, GameMode gameMode)
        {
            NavigateToScoreBoard = new NavigateToScoreboard(navigationStore);
            NavigateToTitleScreenCommand = new NavigateToTitleScreenCommand(navigationStore);
            LightPlayerName = lightPlayerName;
            DarkPlayerName = "COMPUTER";
            GameMode = gameMode;
        }

        public GameViewModel(NavigationStore navigationStore, string lightPlayerName, string darkPlayerName, GameMode gameMode)
        {
            NavigateToScoreBoard = new NavigateToScoreboard(navigationStore);
            NavigateToTitleScreenCommand = new NavigateToTitleScreenCommand(navigationStore);
            LightPlayerName = lightPlayerName;
            DarkPlayerName = darkPlayerName;
            GameMode = gameMode;
        }
    }
}
