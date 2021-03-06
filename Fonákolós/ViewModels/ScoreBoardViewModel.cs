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
            var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string filename = Path.Combine(systemPath, "score.json");

            string json = File.ReadAllText(filename);

            var results = JsonConvert.DeserializeObject<List<Scoreboard>>(json.ToString());

            if (results != null)
            {
                foreach (var result in results)
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
