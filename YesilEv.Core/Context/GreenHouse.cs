using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace YesilEv.Core.Context
{
    public partial class GreenHouse : DbContext
    {
        public GreenHouse()
            : base("name=GreenHouse")
        {
        }

        public virtual DbSet<AppInfo> AppInfo { get; set; }
        public virtual DbSet<Authority> Authority { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductContent> ProductContent { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleAuthority> RoleAuthority { get; set; }
        public virtual DbSet<RoleUser> RoleUser { get; set; }
        public virtual DbSet<SearchHistory> SearchHistory { get; set; }
        public virtual DbSet<Situation> Situation { get; set; }
        public virtual DbSet<Substance> Substance { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProcess> UserProcess { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppInfo>()
                .Property(e => e.AboutUs)
                .IsUnicode(false);

            modelBuilder.Entity<AppInfo>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<AppInfo>()
                .Property(e => e.KullanımKosullari)
                .IsUnicode(false);

            modelBuilder.Entity<Authority>()
                .Property(e => e.AuthorityName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.BarkodNo)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleUser)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.RolId);

            modelBuilder.Entity<Situation>()
                .Property(e => e.Situation1)
                .IsUnicode(false);

            modelBuilder.Entity<Substance>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Substance>()
                .Property(e => e.RisktType)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SocialMedia)
                .IsUnicode(false);
        }
    }
}
