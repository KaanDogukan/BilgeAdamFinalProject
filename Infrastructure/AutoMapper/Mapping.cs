using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.DTO_s.CategoryDTO;
using ApplicationCore.Entities.DTO_s.DirectorDTO;
using ApplicationCore.Entities.DTO_s.MovieDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Director, AddDirectorDTO>().ReverseMap();

            CreateMap<Director, UpdateDirectorDTO>().ReverseMap();
            CreateMap<Director, UpdateDirectorDTO>();

            CreateMap<Category, AddCategoryDTO>().ReverseMap();

            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>();

            CreateMap<Movie, AddMovieDTO>().ReverseMap();

            CreateMap<Movie, UpdateMovieDTO>().ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>();


        }





    }
}
