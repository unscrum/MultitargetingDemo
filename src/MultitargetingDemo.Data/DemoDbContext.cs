using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MultitargetingDemo.Data
{
    public class DemoDbContext:DbContext
    {
        public static DemoDbContext BySqlServerConnectionString(string connectionString, int commandTimeout = 30)
        {
            return new DemoDbContext(new DbContextOptionsBuilder<DemoDbContext>().BySqlServerConnectionString(connectionString, commandTimeout).Options);
        }
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        }
        
        
        public virtual DbSet<Note> Notes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ModelPluralizer<Note>(entity =>
            {
                
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text)
                    .IsRequired();

            });
        }
    }
}