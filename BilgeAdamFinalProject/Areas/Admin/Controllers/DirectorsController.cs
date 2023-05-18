using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.DTO_s.DirectorDTO;
using ApplicationCore.Interfaces;
using AutoMapper;
using BilgeAdamFinalProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace BilgeAdamFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DirectorsController : Controller
    {
        private readonly IRepositoryService<Director> _directorRepo;
        private readonly IMapper _mapper;

        public DirectorsController(IRepositoryService<Director> directorRepo, IMapper mapper)
        {
            _directorRepo = directorRepo;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var directors = await _directorRepo.GetFilteredListAsync
                (
                    select: x=> new GetDirectorVM
                    {
                        Id = x.Id,
                        FullName = x.FirstName +" "+ x.LastName,
                        BirthDate = x.BirthDate,
                        CreatedDate = x.CreatedDate,
                        Status = x.Status,
                        UpdateDate = x.UpdatedDate != null ? x.UpdatedDate : null
                    },
                    where: x=> x.Status != Status.Passive,
                    orderby : x=> x.OrderByDescending(z=> z.CreatedDate)
                );
            return View(directors);

        }

        [HttpGet]
        public IActionResult AddDirector() => View();

        [HttpPost]
        public async Task<IActionResult> AddDirector(AddDirectorDTO model)
        {
            if (ModelState.IsValid)
            {
                var director = _mapper.Map<Director>(model);
                await _directorRepo.AddAsync(director);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDirector(int id)
        {
            var director = await _directorRepo.GetByIdAsync(id);
            if (director != null)
            {
                var model = _mapper.Map<UpdateDirectorDTO>(director);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDirector(UpdateDirectorDTO model)
        {
            if (ModelState.IsValid)
            {
                var director = _mapper.Map<Director>(model);
                await _directorRepo.UpdateAsync(director);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var director = await _directorRepo.GetByIdAsync(id);
            if (director != null)
            {
                await _directorRepo.DeleteAsync(director);
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
