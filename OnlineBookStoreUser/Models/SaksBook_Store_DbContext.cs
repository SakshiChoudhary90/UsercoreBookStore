using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineBookStoreUser.Models
{
    public partial class SaksBook_Store_DbContext : DbContext
    {
        public SaksBook_Store_DbContext()
        {
        }

        public SaksBook_Store_DbContext(DbContextOptions<SaksBook_Store_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BookCategories> BookCategories { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderBooks> OrderBooks { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Publications> Publications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRD-512;Database=SaksBook_Store_Db;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuthorId);
            });

            modelBuilder.Entity<BookCategories>(entity =>
            {
                entity.HasKey(e => e.BookCategoryId);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.HasIndex(e => e.AuthorId);

                entity.HasIndex(e => e.BookCategoryId);

                entity.HasIndex(e => e.PublicationId);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.BookCategory)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.BookCategoryId);

                entity.HasOne(d => d.Publication)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublicationId);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.HasIndex(e => e.UserName)
                    .IsUnique()
                    .HasFilter("([UserName] IS NOT NULL)");
            });

            modelBuilder.Entity<OrderBooks>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.BookId });

                entity.HasIndex(e => new { e.BookId, e.OrderId })
                    .HasName("AK_OrderBooks_BookId_OrderId")
                    .IsUnique();

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderBooks)
                    .HasForeignKey(d => d.BookId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderBooks)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<Publications>(entity =>
            {
                entity.HasKey(e => e.PublicationId);
            });
        }
    }
}
