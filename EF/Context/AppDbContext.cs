using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
       : base(dbContextOptions)
        { }

        public virtual DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Contact__3214EC0754982574");

                entity.ToTable("Contact");

                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}