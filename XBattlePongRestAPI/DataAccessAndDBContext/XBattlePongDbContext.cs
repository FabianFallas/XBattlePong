using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;

namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public class XBattlePongDbContext: DbContext
    {
        public XBattlePongDbContext(DbContextOptions<XBattlePongDbContext> options):base(options) 
        { 
                
        }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Partidas> Partidas { get; set;}
        public DbSet<ReglasDelEvento> ReglasDelEvento { get; set; }
        public DbSet<TokenConEvento> TokenConEvento { get; set; }
    }
}
