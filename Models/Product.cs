using System.ComponentModel.DataAnnotations;

namespace CategoryAndProducts.Web.Models
{
    public class Product : SuperEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public float Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int Period { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
