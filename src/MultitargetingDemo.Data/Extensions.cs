using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MultitargetingDemo.Data
{
    internal static class Extensions
    {   
        internal static DbContextOptionsBuilder<DemoDbContext> BySqlServerConnectionString(
            this DbContextOptionsBuilder<DemoDbContext> options,  string connectionString, int commandTimeout = 30)
        {
            
            return  options.UseSqlServer(connectionString, o => o.CommandTimeout(commandTimeout))
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }
        
        internal static ModelBuilder ModelPluralizer<T>(this ModelBuilder builder, Action<EntityTypeBuilder<T>> action) where T : class
        {
            builder.Entity<T>().ToTable(typeof(T).Name);
            if (action != null)
            {
                return builder.Entity(action);
            }
            return builder;
        }
    }
}