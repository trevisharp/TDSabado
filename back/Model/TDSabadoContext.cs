using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace back.Model
{
    public partial class TDSabadoContext : DbContext
    {
        public TDSabadoContext()
        {
        }

        public TDSabadoContext(DbContextOptions<TDSabadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Follow> Follows { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostImage> PostImages { get; set; } = null!;
        public virtual DbSet<Token> Tokens { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QMC8BF0\\SQLEXPRESS;Initial Catalog=TDSabado;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>(entity =>
            {
                entity.ToTable("Follow");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FollowedId).HasColumnName("FollowedID");

                entity.Property(e => e.FollowerId).HasColumnName("FollowerID");

                entity.HasOne(d => d.Followed)
                    .WithMany(p => p.FollowFolloweds)
                    .HasForeignKey(d => d.FollowedId)
                    .HasConstraintName("FK__Follow__Followed__32E0915F");

                entity.HasOne(d => d.Follower)
                    .WithMany(p => p.FollowFollowers)
                    .HasForeignKey(d => d.FollowerId)
                    .HasConstraintName("FK__Follow__Follower__33D4B598");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Likes__PostId__2F10007B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Likes__UserID__300424B4");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.Moment).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Post__UserID__29572725");
            });

            modelBuilder.Entity<PostImage>(entity =>
            {
                entity.ToTable("PostImage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bytes).HasColumnType("image");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostImages)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__PostImage__PostI__2C3393D0");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("Token");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Token__UserID__267ABA7A");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Userpass).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
