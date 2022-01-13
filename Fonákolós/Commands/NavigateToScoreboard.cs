using Fonákolós.Models;
using Fonákolós.Stores;
using Fonákolós.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonákolós.Commands
{
    public class NavigateToScoreboard : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateToScoreboard(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ScoreBoardViewModel(_navigationStore);
        }
    }
}
