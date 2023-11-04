using shared.Books;
using Biblioteka.Services;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Book> Products { get; set; }

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

            // data seed 

            modelBuilder.Entity<Book>().HasData(BookSeeder.GenerateBooksData());
        }
    }
}
