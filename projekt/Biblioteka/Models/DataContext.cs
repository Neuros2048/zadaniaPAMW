using shared.Books;
using Biblioteka.Services;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Auth;

namespace Biblioteka.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Book> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api 

            modelBuilder.Entity<Book>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Book>()
                .Property(p => p.Author)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Book>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
             .Property(p => p.NumberOfBooks)
             .IsRequired();
            
            //USer

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .IsRequired();
                

            modelBuilder.Entity<User>()
                .Property(p => p.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.PasswordSalt)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Role)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.DateCreated)
                .IsRequired();

            // data seed 

            modelBuilder.Entity<Book>().HasData(BookSeeder.GenerateBooksData());
        }
    }
}
