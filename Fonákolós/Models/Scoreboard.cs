using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonákolós.Models
{
    public class Scoreboard
    {
        public long Id { get; set; }
        public string LightPlayerName { get; set; }
        public long LightPlayerScore { get; set; }
        public string DarkPlayerName { get; set; }
        public long DarkPlayerScore { get; set; }
        public string Winner { get; set; }
        public long GameTime { get; set; }

    }
}
