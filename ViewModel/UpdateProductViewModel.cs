using System.ComponentModel.DataAnnotations;

namespace CategoryAndProducts.Web.ViewModel
{
    public class UpdateProductViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public float Price { get; set; }
        
    }
}
