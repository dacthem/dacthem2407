namespace WebCoreApp.Models
{
    public class ProductViewModel
    {
        public List<ProductResponse> Products { get; set; }
        public List<CategoryResponse> Responses { get; set; }
        public ProductRequest ProductRequest { get; set; }
    }
}
