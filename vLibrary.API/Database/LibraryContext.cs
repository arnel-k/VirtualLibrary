using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Model;
using vLibrary.Model.Enums;

namespace vLibrary.API.Database
{
    public class LibraryContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<BookItem> BookItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>().HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<Account>().Property(r => r.Role).HasConversion(v => v.ToString(), v => (Role)Enum.Parse(typeof(Role), v));
            //modelBuilder.Entity<User>().HasOne(i => i.Library).WithMany(i => i.User).IsRequired().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<BookItem>().HasOne(i => i.Library).WithMany(i => i.BookItems).IsRequired().OnDelete(DeleteBehavior.Cascade);
            
        }
    }
    
    
}
