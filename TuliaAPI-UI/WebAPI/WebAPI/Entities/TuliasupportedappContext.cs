using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Entities
{
    public partial class TuliasupportedappContext : DbContext
    {
        public TuliasupportedappContext()
        {
        }

        public TuliasupportedappContext(DbContextOptions<TuliasupportedappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__PostId__2739D489");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comments__UserId__2645B050");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.GroupTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Groups__UserId__1F98B2C1");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasOne(d => d.LikedPost)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.LikedPostId)
                    .HasConstraintName("FK__Likes__LikedPost__44CA3770");

                entity.HasOne(d => d.SourceUser)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.SourceUserId)
                    .HasConstraintName("FK__Likes__SourceUse__43D61337");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("Membership");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Membershi__Group__2B0A656D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Membershi__UserI__2A164134");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Body)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__GroupId__236943A5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Posts__UserId__22751F6C");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ReportContent)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reports__PostId__2EDAF651");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reports__UserId__2DE6D218");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
