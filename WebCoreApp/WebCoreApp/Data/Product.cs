using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreApp.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [StringLength(500)]
        public string? AvatarUrl { get; set; }
        [NotMapped]
        public IFormFile Avatar { get; set; }
        public int Price { get; set; }
        public DateTime DateCreated {get;set;}
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
