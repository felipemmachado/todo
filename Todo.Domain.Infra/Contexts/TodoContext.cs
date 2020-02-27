using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TodoItem>().ToTable("Todo");
            modelBuilder.Entity<TodoItem>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)").IsRequired();
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)").IsRequired();
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit").IsRequired();
            modelBuilder.Entity<TodoItem>().Property(x => x.Date).IsRequired();
            modelBuilder.Entity<TodoItem>().HasIndex(x => x.User);
        }
    }
}