using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Slider : BaseEntity
    {
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }


        [Required(ErrorMessage ="Description is required")]
        public string Desc { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
