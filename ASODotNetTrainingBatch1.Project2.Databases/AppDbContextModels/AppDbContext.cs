using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASODotNetTrainingBatch1.Project3.Databases.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlogDetail> TblBlogDetails { get; set; }

    public virtual DbSet<TblBlogHeader> TblBlogHeaders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL2022Express;Database=DreamDictionary;User Id=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlogDetail>(entity =>
        {
            entity.HasKey(e => e.BlogDetailId);

            entity.ToTable("Tbl_BlogDetail");

            entity.Property(e => e.BlogDetailId).ValueGeneratedNever();
            entity.Property(e => e.BlogContent).HasMaxLength(150);

            // Optional: Model-only relationship (not enforced in DB)
            entity.HasOne(d => d.BlogHeader)
                  .WithMany(p => p.TblBlogDetails)
                  .HasForeignKey(d => d.BlogId)
                  .OnDelete(DeleteBehavior.ClientSetNull); // or DeleteBehavior.Restrict
        });

        modelBuilder.Entity<TblBlogHeader>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_BlogHeader");

            entity.Property(e => e.BlogId).ValueGeneratedNever();
            entity.Property(e => e.BlogTitle).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
