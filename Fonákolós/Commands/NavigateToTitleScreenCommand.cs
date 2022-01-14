using Fonákolós.Stores;
using Fonákolós.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonákolós.Commands
{
    internal class NavigateToTitleScreenCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateToTitleScreenCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new TitleScreenViewModel(_navigationStore);
        }
    }
}
