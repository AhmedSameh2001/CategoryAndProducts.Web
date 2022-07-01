using System.ComponentModel.DataAnnotations;

namespace CategoryAndProducts.Web.ViewModel
{
    public class CreateCategoryViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
