using Fonákolós.Stores;
using Fonákolós.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonákolós.Commands
{
    public class NavigateToGameCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateToGameCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new GameViewModel();
        }
    }
}
