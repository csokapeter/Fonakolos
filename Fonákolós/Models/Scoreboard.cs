using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonákolós.Models
{

    public class Scoreboard
    {
        /*public int Id { get; set; }*/
        public String LightPlayerName { get; set; }
        public int LightScore { get; set; }
        public String DarkPlayerName { get; set; }
        public int DarkScore { get; set; }
        public String Winner { get; set; }
        public int GameTime { get; set; }
        public override string ToString()
        {
            return $"{LightPlayerName},{LightScore}, {DarkPlayerName}, {DarkScore}, {Winner}, {GameTime}";
            
        }
    }
}
