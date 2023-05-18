using ApplicationCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Concrete
{
    public class Category : BaseEntity
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        public List<MovieCategory> MovieCategories { get; set;}

    }
}
