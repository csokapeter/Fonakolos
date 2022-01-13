using Fonákolós.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace Fonákolós.Views
{
    /// <summary>
    /// Interaction logic for ScoreBoardView.xaml
    /// </summary>
    public partial class ScoreBoardView : UserControl
    {
        public ScoreBoardView()
        {
            InitializeComponent();
            LoadData();

           /*var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String filename = Path.Combine(systemPath, "score.json");

            try

            {

                Scoreboard scoreboard = JsonConvert.DeserializeObject<Scoreboard>(@"{""Name"" : ""Apple"", ""ExpiryDate"" : ""May"", ""Price"" : 3.99}");

                DataContext = scoreboard;

            }

            catch (Exception ex)

            {


                MessageBox.Show(ex.Message);

            }*/
        }
        public void LoadData()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            String filename = Path.Combine(systemPath, "score.json");

            string str = File.ReadAllText(filename);
           /* RootObject deserializedObject = JsonConvert.DeserializeObject<RootObject>(str);
            dgr.ItemsSource = deserializedObject.response.Scoreboard;*/
        }
    }
}
