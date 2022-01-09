using Fonákolós.Commands;
using Fonákolós.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fonákolós.ViewModels
{
    class TitleScreenViewModel : ViewModelBase
    { 
        public ICommand NavigateToGameCommand { get; }

        public TitleScreenViewModel(NavigationStore navigationStore)
        {
            NavigateToGameCommand = new NavigateToGameCommand(navigationStore);
        }
    }
}
