using Domain.Entities.Core;
using Domain.Entities.Locations;
using Domain.Entities.Metadata;
using Domain.Entities.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class RealDatabase : IdentityDbContext<User, IdentityRole, string>
    {
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=VULLE\\SQLEXPRESS; Database=CleanArchitecture; Trusted_Connection=true; TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Review relationships
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Borrowing relationships
            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.User)
                .WithMany(u => u.Borrowings)
                .HasForeignKey(b => b.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.BookCopy)
                .WithMany(bc => bc.Borrowings)
                .HasForeignKey(b => b.CopyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Reservation relationships
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.BookCopy)
                .WithMany(bc => bc.Reservations)
                .HasForeignKey(r => r.CopyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure automatic Id for branches with Id : int
            modelBuilder.Entity<LibraryBranch>()
                .HasKey(lb => lb.BranchId);
            modelBuilder.Entity<LibraryBranch>()
                .Property(lb => lb.BranchId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Genre>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Publisher>()
                .HasKey(g => g.PublisherId);
            modelBuilder.Entity<Publisher>()
                .Property(g => g.PublisherId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Review>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Review>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Borrowing>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Borrowing>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Reservation>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Reservation>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();
        }

    }
}