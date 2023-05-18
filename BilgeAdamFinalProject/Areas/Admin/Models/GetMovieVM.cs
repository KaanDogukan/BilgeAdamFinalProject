using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BilgeAdamFinalProject.Areas.Admin.Models
{
    public class GetMovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
        public int Year { get; set; }
        public string DirectorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }


    }
}
