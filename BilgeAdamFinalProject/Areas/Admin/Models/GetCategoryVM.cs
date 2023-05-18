using ApplicationCore.Entities.Abstract;

namespace BilgeAdamFinalProject.Areas.Admin.Models
{
    public class GetCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }

    }
}
