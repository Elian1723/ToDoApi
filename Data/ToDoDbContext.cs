using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApi.Enums;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.HasKey(e => e.ToDoId);

                entity.Property(e => e.ToDoId)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsRequired();
                entity.Property(e => e.Priority)
                    .HasConversion(new EnumToStringConverter<ToDoPriority>())
                    .IsRequired();
                entity.Property(e => e.State)
                    .HasConversion(new EnumToStringConverter<ToDoState>())
                    .IsRequired();
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
                entity.Property(e => e.DeletedAt)
                    .IsRequired(false);
                entity.Property(e => e.DueDate)
                    .IsRequired();
                entity.Property(e => e.CategoryId)
                    .IsRequired(false);

                entity.HasOne(e => e.Category).WithMany(c => c.ToDos).OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}