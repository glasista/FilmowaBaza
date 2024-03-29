﻿using FilmowaBaza.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmowaBaza.Domain
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptionsBuilder<AppDbContext> _optionsBuilder;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext(DbContextOptionsBuilder<AppDbContext> optionsBuilder) : base(optionsBuilder.Options)
        {
            this._optionsBuilder = optionsBuilder;
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
        //TODO 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
