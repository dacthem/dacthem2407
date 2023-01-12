using WebCoreApp.Models;

namespace WebCoreApp.Services
{
    public interface ICategoryService
    {
        string Delete(int id);
        CategoryResponse Get(int id);
        List<CategoryResponse> GetList();
        string Insert(CategoryResponse cr);
        string Update(CategoryResponse cr);
        
    }
}