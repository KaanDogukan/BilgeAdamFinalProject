using ApplicationCore.Entities.Concrete;
using ApplicationCore.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieCategoryService : IMovieCategoryService
    {
        private readonly AppDbContext _context;

        public MovieCategoryService(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddMovieCategory(MovieCategory movieCategory)
        {
            await _context.MovieCategories.AddAsync(movieCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyByMovieId(int movieId, int categoryId)
        {
            return await _context.MovieCategories.AnyAsync(x => x.CategoryId == categoryId && x.MovieId == movieId);
        }

        public async Task DeleteMovieCategory(int categoryId, int movieId)
        {
            var movieCategory = await _context.MovieCategories.FirstOrDefaultAsync(x => x.MovieId == movieId && x.CategoryId == categoryId);
            _context.MovieCategories.Remove(movieCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MovieCategory>> GetAllByMovieId(int id)
        {
            return await _context.MovieCategories.Where(x=> x.MovieId == id).ToListAsync();   
        }

        public async Task<List<Category>> GetCategoriesByMovieId(int movieId)
        {
            var movieCategories = await _context.MovieCategories.Where(x=> x.MovieId == movieId).ToListAsync();
            List<Category> categories = new List<Category>();
            foreach (var movieCategory in movieCategories)
            {
                var category = await _context.Categeories.FindAsync(movieCategory.CategoryId);
                categories.Add(category);
            }
            return categories;
        }

        public List<string> GetStringCategoriesByMovieId(int movieId)
        {
            var movieCategories = _context.MovieCategories.Where(x => x.MovieId == movieId).ToList();
            List<string> categories = new List<string>();
            foreach (var movieCategory in movieCategories)
            {
                var category = _context.Categeories.Find(movieCategory.CategoryId);
                categories.Add(category.Name);
            }
            return categories;
        }
    }
}
