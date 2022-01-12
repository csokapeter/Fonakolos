using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fonákolós.Models;
using Microsoft.EntityFrameworkCore;

namespace Fonákolós.Models
{
    public class ScoreboardContext : DbContext
    {
        public ScoreboardContext([NotNull] DbContextOptions options) :base(options)
        {

        }
        public DbSet <Scoreboard> Score { get; set; }
    }
}
