using System.ComponentModel.DataAnnotations;

namespace CategoryAndProducts.Web.Models
{
    public class SuperEntity
    {
        public int CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? UpdateAt { get; set; }
        public bool isDelete { get; set; }
    }
}
