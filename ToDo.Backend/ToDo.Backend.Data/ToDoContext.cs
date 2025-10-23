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
            });
        }
    }
}