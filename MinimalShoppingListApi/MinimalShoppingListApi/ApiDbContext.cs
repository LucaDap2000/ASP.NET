using Microsoft.EntityFrameworkCore;

namespace MinimalShoppingListApi
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Grocery> Groceries => Set<Grocery>();

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
    }
}
