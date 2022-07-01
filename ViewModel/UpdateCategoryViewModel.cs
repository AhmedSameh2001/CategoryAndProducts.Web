using System.ComponentModel.DataAnnotations;

namespace CategoryAndProducts.Web.ViewModel
{
    public class UpdateCategoryViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
