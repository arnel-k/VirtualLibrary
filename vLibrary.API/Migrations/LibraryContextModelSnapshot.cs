﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vLibrary.API.Context;

namespace vLibrary.API.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vLibrary.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatus");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Role")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("vLibrary.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("vLibrary.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("FName");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LName");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("vLibrary.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookStatus");

                    b.Property<int>("CategoryId");

                    b.Property<Guid>("Guid");

                    b.Property<string>("ISBN");

                    b.Property<byte[]>("Image");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LibraryId");

                    b.Property<int>("NumberOfPages");

                    b.Property<DateTime>("PublicationDate");

                    b.Property<int>("PublisherId");

                    b.Property<int>("RackId");

                    b.Property<string>("Subject");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LibraryId");

                    b.HasIndex("PublisherId");

                    b.HasIndex("RackId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("vLibrary.Model.BookLeading", b =>
                {
                    b.Property<int>("MemberId");

                    b.Property<int>("BookId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("DueDate");

                    b.Property<int?>("NotificationId");

                    b.Property<DateTime?>("ReturnDate");

                    b.Property<bool>("Returned");

                    b.HasKey("MemberId", "BookId");

                    b.HasIndex("BookId");

                    b.HasIndex("NotificationId");

                    b.ToTable("BookLeadings");
                });

            modelBuilder.Entity("vLibrary.Model.Book_Author", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book_Authors");
                });

            modelBuilder.Entity("vLibrary.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("vLibrary.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<int>("LibraryId");

                    b.Property<string>("Phone");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("LibraryId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("vLibrary.Model.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("vLibrary.Model.LibraryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("CardNumber");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("IssuedAt");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("LibraryCards");
                });

            modelBuilder.Entity("vLibrary.Model.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("DateOfMemberShip");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<int>("NumberOfBooksLoaned");

                    b.Property<string>("Phone");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("AddressId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("vLibrary.Model.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreationDate");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("vLibrary.Model.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MemberId");

                    b.Property<DateTime>("PaymantDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("vLibrary.Model.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("PublisherName");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("vLibrary.Model.Rack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LocationIdentification");

                    b.Property<int>("RackNumber");

                    b.HasKey("Id");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("vLibrary.Model.Book", b =>
                {
                    b.HasOne("vLibrary.Model.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vLibrary.Model.Library", "Library")
                        .WithMany("Books")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Model.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Model.Rack", "Rack")
                        .WithMany("Books")
                        .HasForeignKey("RackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Model.BookLeading", b =>
                {
                    b.HasOne("vLibrary.Model.Book", "Book")
                        .WithMany("BookLeadings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vLibrary.Model.Member", "Member")
                        .WithMany("BookLeadings")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vLibrary.Model.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId");
                });

            modelBuilder.Entity("vLibrary.Model.Book_Author", b =>
                {
                    b.HasOne("vLibrary.Model.Author", "Author")
                        .WithMany("Book_Authors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Model.Book", "Book")
                        .WithMany("Book_Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Model.Employee", b =>
                {
                    b.HasOne("vLibrary.Model.Address", "Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Model.Library", "Library")
                        .WithMany("Employees")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Model.Library", b =>
                {
                    b.HasOne("vLibrary.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Model.LibraryCard", b =>
                {
                    b.HasOne("vLibrary.Model.Account", "Account")
                        .WithOne("LibraryCard")
                        .HasForeignKey("vLibrary.Model.LibraryCard", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Model.Member", b =>
                {
                    b.HasOne("vLibrary.Model.Account", "Account")
                        .WithOne("Member")
                        .HasForeignKey("vLibrary.Model.Member", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Model.Address", "Address")
                        .WithMany("Member")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Model.Payment", b =>
                {
                    b.HasOne("vLibrary.Model.Member", "Member")
                        .WithMany("Payments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
