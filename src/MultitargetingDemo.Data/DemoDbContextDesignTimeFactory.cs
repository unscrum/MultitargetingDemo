using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MultitargetingDemo.Data
{
    public class DemoDbContextDesignTimeFactory : IDesignTimeDbContextFactory<DemoDbContext>
    {
        public DemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DemoDbContext>();
            builder.UseSqlServer("Server=.;Database=Demo;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new DemoDbContext(builder.Options);
        }
    }
}