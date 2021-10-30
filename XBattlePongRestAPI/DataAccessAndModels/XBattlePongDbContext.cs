using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace XBattlePongRestAPI.DataAccessAndModels
{
    public class XBattlePongDbContext: DbContext
    {
        public XBattlePongDbContext(DbContextOptions<XBattlePongDbContext> options):base(options) 
        { 
                
        }
        public DbSet<Eventos> Eventos { get; set; }
    }
}
