using WebCoreApp.Models;

namespace WebCoreApp.Services
{
    public interface IProductService
    {
        List<ProductResponse> GetList();
        List<CategoryResponse> GetIdList();
        List<ProductResponse> GetListByCateId(int id);
        ProductRequest Get(int id);
        string Delete(int id);
        string Create(ProductRequest Request);
        string Update(ProductRequest Request);
    }
}