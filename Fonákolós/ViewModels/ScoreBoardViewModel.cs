using System;
using Fonákolós.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using Fonákolós.Models;
using System.Windows.Input;
using Fonákolós.Commands;

namespace Fonákolós.ViewModels
{
    public class ScoreBoardViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ObservableCollection<string> Results { get; set; }

        public ICommand NavigateToTitleScreenCommand { get; }
        public ScoreBoardViewModel(NavigationStore navigationStore)
        {            
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            NavigateToTitleScreenCommand = new NavigateToTitleScreenCommand(navigationStore);

            Results = new ObservableCollection<string>();
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String filename = Path.Combine(systemPath, "score.json");

            string json = System.IO.File.ReadAllText(filename);

            var x = JsonConvert.DeserializeObject<List<Scoreboard>>(json.ToString());

            if (x != null)
            {
                foreach (var result in x) 
                { 
                    Results.Add(result.ToString());
                }
            }
            
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
