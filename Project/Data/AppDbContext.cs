﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CollectionItem>()
                .HasMany(i => i.CustomIntFields)
                .WithOne(f => f.Item)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CollectionItem>()
                .HasMany(i => i.CustomStringFields)
                .WithOne(f => f.Item)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CollectionItem>()
                .HasMany(i => i.CustomTextAreaFields)
                .WithOne(f => f.Item)
                .OnDelete(DeleteBehavior.Cascade);            
            builder.Entity<CollectionItem>()
                .HasMany(i => i.CustomBoolFields)
                .WithOne(f => f.Item)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CollectionItem>()
                .HasMany(i => i.CustomDateFields)
                .WithOne(f => f.Item)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Collection>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Collection)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Collections)
                .WithOne(c => c.Author)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Like>()
                .HasOne(l => l.Item)
                .WithMany(i => i.Likes)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Comment>()
                .HasOne(c => c.Item)
                .WithMany(i => i.Comments)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Tag>()
                .HasOne(t => t.Item)
                .WithMany(i => i.Tags)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
