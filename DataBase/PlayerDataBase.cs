using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace DataBase
{
    public class PlayerDataBase: DbContext
    {
        public DbSet<Player> Player { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B62IM5F;Database=PlayersLogins;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
