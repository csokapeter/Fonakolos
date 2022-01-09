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
            if (_gameMode == GameMode.MULTIPLAYER && !string.IsNullOrWhiteSpace(_viewModel.LightPlayerName) && !string.IsNullOrWhiteSpace(_viewModel.DarkPlayerName))
            {
                _navigationStore.CurrentViewModel = new GameViewModel(_viewModel.LightPlayerName, _viewModel.DarkPlayerName, _gameMode);
            }
            else if (_gameMode == GameMode.MULTIPLAYER)
            {
                MessageBox.Show("Adja meg mind a két felhasználónevet!");
            }
            else if (_gameMode == GameMode.SOLO && !string.IsNullOrWhiteSpace(_viewModel.LightPlayerName))
            {
                _navigationStore.CurrentViewModel = new GameViewModel(_viewModel.LightPlayerName, _gameMode);
            }
            else
            {
                MessageBox.Show("Adja meg az első játékkos felhasználónevet!");
            }
        }
    }
}
