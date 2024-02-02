using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Concrete
{
    public class ACRContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LAPTOP-IPQTP7GR;Database = ACR_Db;Integrated security =true;");
        }
        public DbSet<Autoclave> autoclaves { get; set; }
        public DbSet<Register> registers { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<ReservationStatus> reservationStatuses { get; set; }

    }
}
