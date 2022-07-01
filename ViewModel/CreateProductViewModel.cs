using System.ComponentModel.DataAnnotations;

namespace CategoryAndProducts.Web.ViewModel
{
    public class CreateProductViewModel
    {
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        [Display(Name = "Product Price")]
        public float Price { get; set; }
        [Display(Name = "Category ID for product")]
        public string CategoryID { get; set; }
        [Required]
        [Display(Name = "Product Image")]
        public IFormFile ImageUrl { get; set; }
    }
}
