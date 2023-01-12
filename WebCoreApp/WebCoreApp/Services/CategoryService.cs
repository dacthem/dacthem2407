using WebCoreApp.Data;
using WebCoreApp.Models;
namespace WebCoreApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<CategoryResponse> GetList()                 
        {
            var rs = _db.Category.Select(e => new CategoryResponse
            {
                Id = e.ID,
                Name=e.Name
            }).ToList();
            return rs;
        }
        public CategoryResponse Get(int id)
        {
            var rs = _db.Category.Where(e => e.ID == id).Select(e=> new CategoryResponse 
            { 
                Id=e.ID,
                Name=e.Name
            }).FirstOrDefault();
            
            return rs;
        }
        public string Delete(int id)
        {
            var obj = _db.Category.Where(e => e.ID == id).FirstOrDefault();
            if (obj != null)
            {
                _db.Category.Remove(obj);
                _db.SaveChanges();
            }
            return String.Empty;
        }
        public string Insert(CategoryResponse cr)
        {
            var obj = new Category
            {
                Name = cr.Name
            };
            _db.Category.Add(obj);
            _db.SaveChanges();
            return String.Empty;
            
        }
        public string Update(CategoryResponse cr)
        {
            var obj = _db.Category.Where(e => e.ID == cr.Id).FirstOrDefault();
            if (obj != null)
            {
                obj.Name = cr.Name;
                _db.SaveChanges();
                return string.Empty;
            } else
            {
                return "Khong tim thay doi tuong";
            }
        }
    }
}
