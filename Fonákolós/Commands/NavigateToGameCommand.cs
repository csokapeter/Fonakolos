using Fonákolós.Models;
using Fonákolós.Stores;
using Fonákolós.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fonákolós.Commands
{
    public class NavigateToGameCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly TitleScreenViewModel _viewModel;
        private readonly GameMode _gameMode;

        public NavigateToGameCommand(TitleScreenViewModel viewModel, NavigationStore navigationStore, GameMode gameMode)
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
            _gameMode = gameMode;
        }

        public override void Execute(object parameter)
        {
            if (_gameMode == GameMode.MULTIPLAYER && !IsNullOrWhiteSpaceOrSpecialChar(_viewModel.LightPlayerName) && !IsNullOrWhiteSpaceOrSpecialChar(_viewModel.DarkPlayerName))
            {
                _navigationStore.CurrentViewModel = new GameViewModel(_navigationStore, _viewModel.LightPlayerName, _viewModel.DarkPlayerName, _gameMode);
            }
            else if (_gameMode == GameMode.MULTIPLAYER)
            {
                MessageBox.Show("Adja meg mind a két felhasználónevet! A nevekben csak betűk és számok lehetnek!");
            }
            else if (_gameMode == GameMode.SOLO && !IsNullOrWhiteSpaceOrSpecialChar(_viewModel.LightPlayerName))
            {
                _navigationStore.CurrentViewModel = new GameViewModel(_navigationStore, _viewModel.LightPlayerName, _gameMode);
            }
            else
            {
                MessageBox.Show("Adja meg az első játékkos felhasználónevet! A névben csak betűk és számok lehetnek!");
            }
        }

        public bool IsNullOrWhiteSpaceOrSpecialChar(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                return username.Any(ch => !Char.IsLetterOrDigit(ch));
            }
            return true;
        }
    }
}
