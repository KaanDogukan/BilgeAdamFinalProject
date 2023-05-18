using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.DTO_s.CategoryDTO;
using ApplicationCore.Interfaces;
using AutoMapper;
using BilgeAdamFinalProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BilgeAdamFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly IRepositoryService<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public CategoriesController(IRepositoryService<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepo.GetFilteredListAsync
                (
                select : x=> new GetCategoryVM
                {
                    Id= x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    Status = x.Status,
                    UpdateDate = x.UpdatedDate
                },
                where : x=> x.Status != ApplicationCore.Entities.Abstract.Status.Passive,
                orderby : x=> x.OrderByDescending(z=> z.CreatedDate)
                );
            return View(categories);

        }

        [HttpGet]
        public IActionResult AddCategory() => View();

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);
                await _categoryRepo.AddAsync(category);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category != null)
            {
                var model = _mapper.Map<UpdateCategoryDTO>(category);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);
                await _categoryRepo.UpdateAsync(category);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category != null)
            {
                await _categoryRepo.DeleteAsync(category);
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
