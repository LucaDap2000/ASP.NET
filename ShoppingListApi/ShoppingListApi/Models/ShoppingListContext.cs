using Microsoft.EntityFrameworkCore;

namespace ShoppingListApi.Models
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options)
        {
            
        }

        public DbSet<Grocery> Grocery { get; set; }
    }
}
