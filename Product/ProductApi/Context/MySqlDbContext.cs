using Microsoft.EntityFrameworkCore;
using ProductApi.Context.ConfigurationEntity;
using ProductApi.Models;

namespace ProductApi.Context
{
    public class MySqlDbContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public MySqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("MySQlConnectionString");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfigureExtensionType());
        }
    }
}
