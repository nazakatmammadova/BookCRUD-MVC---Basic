using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookCRUD.Models;

public partial class BookMvcContext : DbContext
{
    public BookMvcContext()
    {
    }

    public BookMvcContext(DbContextOptions<BookMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DM6B8LT;Database=BookMVC;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Author__3214EC0765F0FDAC");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorName).HasMaxLength(25);
            entity.Property(e => e.AuthorSurname).HasMaxLength(25);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Book__3214EC07555A64C0");

            entity.ToTable("Book");

            entity.Property(e => e.BookName).HasMaxLength(100);

            entity.HasOne(d => d.BookAuthor).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookAuthorId)
                .HasConstraintName("FK__Book__BookAuthor__3C69FB99");

            entity.HasOne(d => d.BookGenre).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookGenreId)
                .HasConstraintName("FK__Book__BookGenreI__3B75D760");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC07880EA9D9");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreName).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
