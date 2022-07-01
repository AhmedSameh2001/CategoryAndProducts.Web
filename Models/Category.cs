using System.ComponentModel.DataAnnotations;

namespace CategoryAndProducts.Web.Models
{
    public class Category : SuperEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }

        public List<Product> Products { get; set; }
    }
}
