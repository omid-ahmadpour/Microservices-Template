namespace Slice.Services.Identity.Infrastructure.Db
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Slice.Framework.Common.Utilities;
    using Slice.Framework.Core.Entities;
    using Slice.Services.Identity.Core.Entities;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entitiesAssembly = typeof(IEntity).Assembly;

            modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntity).Assembly);
            modelBuilder.AddPluralizingTableNameConvention();
        }
    }
}
