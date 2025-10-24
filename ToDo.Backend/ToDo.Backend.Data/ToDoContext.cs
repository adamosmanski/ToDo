using Microsoft.EntityFrameworkCore;
using ToDo.Backend.Data.Model;

namespace ToDo.Backend.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {

        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.ToTable("todo_items");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                      .HasColumnName("title")
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .HasColumnName("description")
                      .HasMaxLength(1000);

                entity.Property(e => e.IsCompleted)
                      .HasColumnName("is_completed")
                      .HasDefaultValue(false);

                entity.Property(e => e.CreatedAt)
                      .HasColumnName("created_at")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasData(
                    new ToDoItem { Id = 1,Title = "Zadanie 1", Description = "Opis 1", IsCompleted = false, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc) },
                    new ToDoItem { Id = 2, Title = "Zadanie 2", Description = "Opis 2", IsCompleted = true, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc) },
                    new ToDoItem { Id = 3, Title = "Zadanie 3", Description = "Opis 3", IsCompleted = false, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc) },
                    new ToDoItem { Id = 4, Title = "Zadanie 4", Description = "Opis 4", IsCompleted = false, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc) },
                    new ToDoItem { Id = 5, Title = "Zadanie 5", Description = "Opis 5", IsCompleted = true, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc) },
                    new ToDoItem { Id = 6, Title = "Zadanie 6", Description = "Opis 6", IsCompleted = false, CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc) });
            });
        }
    }
}