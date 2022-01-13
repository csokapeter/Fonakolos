using Fonákolós.Commands;
using Fonákolós.Models;
using Fonákolós.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fonákolós.ViewModels
{
    public class TitleScreenViewModel : ViewModelBase
    {
        private string _lightPlayerName;
        private string _darkPlayerName;

        public string LightPlayerName 
        {
            get { return _lightPlayerName; }
            set
            {
                _lightPlayerName = value;
                OnPropertyChanged(nameof(LightPlayerName));
            }
        }

        public string DarkPlayerName
        {
            get { return _darkPlayerName; }
            set
            {
                _darkPlayerName = value;
                OnPropertyChanged(nameof(DarkPlayerName));
            }
        }

        public ICommand NavigateToGameCommand { get; }
        public ICommand NavigateToGameCommandComputer { get; }
        public ICommand NavigateToScoreboard { get; }

        public TitleScreenViewModel(NavigationStore navigationStore)
        {
            NavigateToGameCommand = new NavigateToGameCommand(this, navigationStore, GameMode.MULTIPLAYER);
            NavigateToGameCommandComputer = new NavigateToGameCommand(this, navigationStore, GameMode.SOLO);
            NavigateToScoreboard = new NavigateToScoreboard(navigationStore);
        }
    }
}
