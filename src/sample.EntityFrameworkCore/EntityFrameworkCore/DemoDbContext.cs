using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace sample.EntityFrameworkCore
{
    [ConnectionStringName("Demo")]

    public class DemoDbContext: AbpDbContext<DemoDbContext>,ITransientDependency
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Book>(b =>
            {
                b.ToTable(sampleConsts.DbTablePrefix + "Books", sampleConsts.DbSchema);
                b.ConfigureByConvention();
            });
        }
        }
}

