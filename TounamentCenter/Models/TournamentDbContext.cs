using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TournamentCenter.Models
{
    public class TournamentDbContext : DbContext
    {
        public DbSet<Tournament> Tournament { get; set; }
    }
}