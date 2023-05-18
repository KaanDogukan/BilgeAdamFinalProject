using ApplicationCore.Entities.Abstract;

namespace BilgeAdamFinalProject.Areas.Admin.Models
{
    public class GetDirectorVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }
    }
}
