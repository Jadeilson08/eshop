using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext()
        {
        }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {

        }
    }
}
