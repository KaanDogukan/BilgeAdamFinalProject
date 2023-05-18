using ApplicationCore.Entities.Concrete;
using ApplicationCore.Interfaces;
using BilgeAdamFinalProject.Areas.Admin.Models;
using BilgeAdamFinalProject.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BilgeAdamFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryService<Movie> _moviesRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDirectorService _directorRepo;
        private readonly IMovieCategoryService _movieCategoriesRepo;

        public HomeController(ILogger<HomeController> logger, IRepositoryService<Movie> moviesRepo, IMovieCategoryService movieCategoriesRepo, IWebHostEnvironment webHostEnvironment, IDirectorService directorRepo)
        {
            _logger = logger;
            _moviesRepo = moviesRepo;
            _webHostEnvironment = webHostEnvironment;
            _directorRepo = directorRepo;
            _movieCategoriesRepo = movieCategoriesRepo;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Directory = _webHostEnvironment.WebRootPath;
            var movies = await _moviesRepo.GetFilteredListAsync
                (
                    select: x => new GetMovieVM
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        DirectorName = x.Director.FirstName + " " + x.Director.LastName,
                        Image = x.Image != null ? x.Image : "noimage.png",
                        Year = x.Year,
                        CreatedDate = x.CreatedDate,
                        UpdateDate = x.UpdatedDate,
                        Status = x.Status,
                        Categories = _movieCategoriesRepo.GetStringCategoriesByMovieId(x.Id)
                    },
                    where: x => x.Status != ApplicationCore.Entities.Abstract.Status.Passive,
                    orderby: x => x.OrderByDescending(z => z.CreatedDate),
                    join: x => x.Include(z => z.Director)
                );
            return View(movies);
        }


        public async Task<IActionResult> MovieDetail(int id)
        {
            var movie = await _moviesRepo.GetByIdAsync(id);
            var director = await _directorRepo.GetByIdAsync(movie.DirectorId);
            var model = new GetMovieDetailVM
            {
                Name = movie.Name,
                Description = movie.Description,
                DirectorName = director.FirstName + " " + director.LastName,
                Image = movie.Image != null ? movie.Image : "noimage.png",
                Year = movie.Year,
                Categories = _movieCategoriesRepo.GetStringCategoriesByMovieId(movie.Id)
            };
            return View(model);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}