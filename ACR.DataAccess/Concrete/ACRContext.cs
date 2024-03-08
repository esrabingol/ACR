using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ACR.DataAccess.Concrete
{
    public class ACRContext : DbContext
    {
        public ACRContext(DbContextOptions<ACRContext> options) : base(options)
        {
        }
        public ACRContext()
        {

        }
        public DbSet<Machine> Machines { get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Reservation> Reservations {get; set;}
        public DbSet<Role> Roles {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionStrings");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Users - Rezervation ilişkisi
            //modelBuilder.Entity<Users>()
            //    .HasMany(u => u.ConfirmedReservations) //Onaylanmış randevular
            //    .WithOne(r => r.Operator)
            //    .HasForeignKey(r => r.OperatorId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Users>()
            //    .HasMany(u => u.RequestedReservations) //randevu talepleri
            //    .WithOne(r => r.Requester)
            //    .HasForeignKey(r => r.RequesterId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //Users - Role ilişkisi
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(r => r.RoleId);

            //Users - Role ilişkisi
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reservations)
                .WithOne(r => r.Requester)
                .HasForeignKey(r => r.RequesterId);

            //Role - Users ilişkisi
            modelBuilder.Entity<Role>()
                .HasMany(u => u.Users)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId);
        }
    }
}
