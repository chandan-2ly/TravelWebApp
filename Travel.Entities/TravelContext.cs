using Microsoft.EntityFrameworkCore;
using System;
using Travel.Entities.Entity;
using Travel.Entities.Entity.Configurations;

namespace Travel.Entities
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration <UserRole>(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration<Booking>(new BookingConfiguration());
            modelBuilder.ApplyConfiguration<Counter>(new CounterConfiguration());
            modelBuilder.ApplyConfiguration<Driver>(new DriverConfigration());
            modelBuilder.ApplyConfiguration<Passenger>(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration<Slot>(new SlotConfiguration());
            modelBuilder.ApplyConfiguration<Transaction>(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration<Traveller>(new TravellerConfiguration());
        }

        //Entities
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
    }
}
