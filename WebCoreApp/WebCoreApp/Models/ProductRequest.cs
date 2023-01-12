using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCoreApp.Data;

namespace WebCoreApp.Models
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? AvatarUrl { get; set; }
        public IFormFile Avatar { get; set; }
        public int Price { get; set; }
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
