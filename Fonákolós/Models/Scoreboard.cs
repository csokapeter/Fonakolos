using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonákolós.Models
{
    internal class Scoreboard
    {
        public int Id { get; set; }
        public String LightPlayerName { get; set; }
        public int LightPlayerScore { get; set; }
        public String DarkPlayerName { get; set; }
        public int DarkPlayerScore { get; set; }
        public String Winner { get; set; }
        public int GameTime { get; set; }

    }
}
