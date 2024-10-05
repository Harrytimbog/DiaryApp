using Microsoft.EntityFrameworkCore;
using DiaryApp.Models;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { 
                    Id = 1,
                    Title = "Went Hiking",
                    Content = "Went hiking with Dede!",
                    Created = DateTime.Now
                },

                new DiaryEntry
                {
                    Id = 2,
                    Title = "Went to Codonas",
                    Content = "Went to Codonas with Okechukwu",
                    Created = DateTime.Now
                },
                new DiaryEntry
                {
                    Id = 3,
                    Title = "Went Coding",
                    Content = "Went to Coding with CoBots",
                    Created = DateTime.Now
                }

            );
        }
    }
}
