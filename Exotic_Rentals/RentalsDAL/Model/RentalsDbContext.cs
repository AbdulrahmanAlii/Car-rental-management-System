namespace RentalsDAL.Model
{
    using Microsoft.EntityFrameworkCore;

    public class RentalsDbContext : DbContext
    {
        public RentalsDbContext(DbContextOptions<RentalsDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<CarDTO> Cars { get; set; }
        public virtual DbSet<CustomerDTO> Customers { get; set; }
        public virtual DbSet<RentalDTO> Rentals { get; set; }
        public virtual DbSet<ReturnDTO> Returns { get; set; }
        public virtual DbSet<UserDTO> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed in User

            modelBuilder.Entity<UserDTO>()
                 .HasData(new UserDTO
                 {
                     Id = 1,
                     Username = "admin",
                     Password = "123"
                 }
         );

            #endregion Seed in User
        }
    }
}