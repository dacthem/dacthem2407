using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebCoreApp.Data
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
