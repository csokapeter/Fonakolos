using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fonákolós.Models;
using Microsoft.EntityFrameworkCore;

namespace Fonákolós
{
    public class ScoreboardContext : DbContext
    {
        public DbSet<Scoreboard> Score { get; set; }
    }
}
