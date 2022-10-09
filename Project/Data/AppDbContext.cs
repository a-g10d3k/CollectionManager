using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionImage> CollectionImages { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }
        public DbSet<CustomIntField> CustomIntFields { get; set; }
        public DbSet<CustomStringField> CustomStringFields { get; set; }
        public DbSet<CustomTextAreaField> CustomTextAreaFields { get; set; }
        public DbSet<CustomBoolField> CustomBoolFields { get; set; }
        public DbSet<CustomDateField> CustomDateFields { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomField>().ToTable("CustomFields");
            base.OnModelCreating(builder);
        }
    }
}
