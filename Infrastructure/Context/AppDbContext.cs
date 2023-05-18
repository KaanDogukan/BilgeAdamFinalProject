using ApplicationCore.Entities.Concrete;
using Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { Database.Migrate(); }


        // referans vermen lazım. Infrastructure git, dependencies sağ tıkla, açılan pencere projemizi seç ve ok de.
        public DbSet<Category> Categeories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>().HasKey(x => new
            {
                x.MovieId,
                x.CategoryId
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DirectorSeedData());
            modelBuilder.ApplyConfiguration(new MovieSeedData());
            modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new MovieCategorySeedData());




        }



    }
}
