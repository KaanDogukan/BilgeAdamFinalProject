using ApplicationCore.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.DTO_s.MovieDTO
{
    public class UpdateMovieDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(300, ErrorMessage = "Maksimum 100 karakter olmalı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(600, ErrorMessage = "Maksimum 600 karakter olmalı")]
        public string Description { get; set; }

        public int Year { get; set; }

        public int DirectorId { get; set; }
        public string? Image { get; set; }

        public IFormFile? UploadImage { get; set; }

        public List<Category>? AddCategories { get; set; }
        public List<Category>? DeleteCategories { get; set; }
        public string[]? AddIds { get; set; }
        public string[]? DeleteIds { get; set; }





    }
}
