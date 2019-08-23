using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;
using vLibrary.Api.Database.Enums;

namespace vLibrary.API.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        //public DbSet<BookItem> BookItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<BookLeading> BookLeadings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>().HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Book).WithMany(ba => ba.Book_Authors).HasForeignKey(b=>b.BookId);
            modelBuilder.Entity<Book_Author>().HasOne(a => a.Author).WithMany(ba => ba.Book_Authors).HasForeignKey(a => a.AuthorId);
            modelBuilder.Entity<BookLeading>().HasKey(k => new { k.MemberId, k.BookId });
            modelBuilder.Entity<Account>().Property(r => r.Role).HasConversion(v => v.ToString(), v => (Role)Enum.Parse(typeof(Role), v));
            modelBuilder.Entity<Book>().HasMany(x => x.BookLeadings).WithOne(x => x.Book).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Member>().HasMany(x => x.BookLeadings).WithOne(x => x.Member).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Category>().HasMany(x => x.Books).WithOne(x => x.Category).OnDelete(DeleteBehavior.Restrict);
        }
    }
    
    
}
