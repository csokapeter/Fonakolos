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

        public NavigateToGameCommand(TitleScreenViewModel viewModel, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(_viewModel.LightPlayerName) && !string.IsNullOrWhiteSpace(_viewModel.DarkPlayerName))
            {
                _navigationStore.CurrentViewModel = new GameViewModel();
            }
            else
            {
                MessageBox.Show("Adja meg mind a két felhasználónevet!");
            }
        }
    }
}
