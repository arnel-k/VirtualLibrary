﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vLibrary.API.Context;

namespace vLibrary.API.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20191005021605_5.10_AK_Type")]
    partial class _510_AK_Type
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vLibrary.Api.Database.Account", b =>
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

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("vLibrary.Api.Database.Address", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Author", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Book", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.BookLeading", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Book_Author", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book_Authors");
                });

            modelBuilder.Entity("vLibrary.Api.Database.Category", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender")
                        .IsRequired();

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

            modelBuilder.Entity("vLibrary.Api.Database.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Guid");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("vLibrary.Api.Database.LibraryCard", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Member", b =>
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

                    b.Property<int>("LibraryId");

                    b.Property<int>("NumberOfBooksLoaned");

                    b.Property<string>("Phone");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("AddressId");

                    b.HasIndex("LibraryId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("vLibrary.Api.Database.Notification", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Payment", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Publisher", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Rack", b =>
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

            modelBuilder.Entity("vLibrary.Api.Database.Book", b =>
                {
                    b.HasOne("vLibrary.Api.Database.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vLibrary.Api.Database.Library", "Library")
                        .WithMany("Books")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vLibrary.Api.Database.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vLibrary.Api.Database.Rack", "Rack")
                        .WithMany("Books")
                        .HasForeignKey("RackId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("vLibrary.Api.Database.BookLeading", b =>
                {
                    b.HasOne("vLibrary.Api.Database.Book", "Book")
                        .WithMany("BookLeadings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vLibrary.Api.Database.Member", "Member")
                        .WithMany("BookLeadings")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vLibrary.Api.Database.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId");
                });

            modelBuilder.Entity("vLibrary.Api.Database.Book_Author", b =>
                {
                    b.HasOne("vLibrary.Api.Database.Author", "Author")
                        .WithMany("Book_Authors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Api.Database.Book", "Book")
                        .WithMany("Book_Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Api.Database.Employee", b =>
                {
                    b.HasOne("vLibrary.Api.Database.Address", "Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Api.Database.Library", "Library")
                        .WithMany("Employees")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Api.Database.LibraryCard", b =>
                {
                    b.HasOne("vLibrary.Api.Database.Account", "Account")
                        .WithOne("LibraryCard")
                        .HasForeignKey("vLibrary.Api.Database.LibraryCard", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vLibrary.Api.Database.Member", b =>
                {
                    b.HasOne("vLibrary.Api.Database.Account", "Account")
                        .WithOne("Member")
                        .HasForeignKey("vLibrary.Api.Database.Member", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Api.Database.Address", "Address")
                        .WithMany("Member")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vLibrary.Api.Database.Library", "Library")
                        .WithMany("Members")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("vLibrary.Api.Database.Payment", b =>
                {
                    b.HasOne("vLibrary.Api.Database.Member", "Member")
                        .WithMany("Payments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
