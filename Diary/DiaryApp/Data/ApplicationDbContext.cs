using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry 
                { 
                    Id = 1, 
                    Title = "Went Hiking", 
                    Content = "Went hiking with Joe!", 
                    Created = DateTime.Now 
                },
                new DiaryEntry
                {
                    Id = 2,
                    Title = "Went Shopping",
                    Content = "Went shopping with Joe!",
                    Created = DateTime.Now
                },
                new DiaryEntry
                {
                    Id = 3,
                    Title = "Went Diving",
                    Content = "Went diving with Joe!",
                    Created = DateTime.Now
                }
                );
        }

        // Four steps to add a table
        // 1. Create a Model Class
        // 2. Add DB Set
        // 3. add-migration AddDiaryEntryTable
        // 4. update-database
    }
}
