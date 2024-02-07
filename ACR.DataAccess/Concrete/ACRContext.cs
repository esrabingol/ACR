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
       
        public DbSet<Autoclave> Autoclaves { get; set; }
        public DbSet<Users> Registers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users - Rezervation ilişlisi
            modelBuilder.Entity<Users>()
                .HasMany(u => u.ConfirmedReservations) //Onaylanmış randevular
                .WithOne(r => r.Operator)
                .HasForeignKey(r => r.OperatorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Users>()
                .HasMany(u => u.RequestedReservations) //randevu talepleri
                .WithOne(r => r.Requester)
                .HasForeignKey(r => r.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);

            //Users - Role ilişkisi
            modelBuilder.Entity<Users>()
                .HasOne(u => u.SelectedRole)
                .WithMany(r => r.Users)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            //Reservation - ReservationStatus ilişkisi
            modelBuilder.Entity<Reservation>()
                .HasOne(u => u.Status)
                .WithOne(rs => rs.Reservation)
                .HasForeignKey<ReservationStatus>(rs => rs.ReservationId)
                .OnDelete(DeleteBehavior.Cascade); 

            //Role - Users ilişkisi
            modelBuilder.Entity<Role>()
                .HasMany(u => u.Users)
                .WithOne(r => r.SelectedRole)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Restrict);


        }



    }
}
