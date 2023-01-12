using WebCoreApp.Data;
using WebCoreApp.Models;

namespace WebCoreApp.Services
{
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext _db;
		public ProductService(ApplicationDbContext db)
		{
			_db = db;
		}
		public List<ProductResponse> GetList()
		{
			var rs = _db.Product.Select(e => new ProductResponse
			{
				Id = e.Id,
				Name = e.Name,
				Description = e.Description,
				Price = e.Price,
                DateCreated = e.DateCreated,
				CategoryId = e.CategoryId,
                CategoryName=e.Category.Name,
                AvatarUrl=e.AvatarUrl
			}).ToList();
			return rs;
		}
        public List<CategoryResponse> GetIdList()
        {
            var rs = _db.Category.Select(e => new CategoryResponse
            {
                Id = e.ID,
                Name = e.Name,
               
            }).ToList();
            return rs;
        }
        public ProductRequest Get(int id)
        {
            var rs = _db.Product.Where(e => e.Id == id).Select(e => new ProductRequest
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
                DateCreated = e.DateCreated,
                CategoryId = e.CategoryId,
                AvatarUrl=e.AvatarUrl
            }).FirstOrDefault();

            return rs;
        }
        public List<ProductResponse> GetListByCateId(int id)
        {
            var rs = _db.Product.Where(e=>e.CategoryId==id).Select(e => new ProductResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
                DateCreated = e.DateCreated,
                CategoryId = e.CategoryId,
                CategoryName = e.Category.Name,
                AvatarUrl = e.AvatarUrl
            }).ToList();
            return rs;
        }
        public string Delete(int id)
        {
            var obj = _db.Product.Where(e => e.Id == id).FirstOrDefault();
            if (obj != null)
            {
                _db.Product.Remove(obj);
                _db.SaveChanges();
            }
            return String.Empty;
        }
        public string Update(ProductRequest pr)
        {
            var obj = _db.Product.Where(e => e.Id == pr.Id).FirstOrDefault();
            if (obj != null)
            {
                obj.Name = pr.Name;
                obj.Description = pr.Description;
                obj.Price = pr.Price;
                obj.CategoryId = pr.CategoryId;
                obj.AvatarUrl = pr.AvatarUrl;
                _db.SaveChanges();
                return string.Empty;
            }
            else
            {
                return "Khong tim thay doi tuong";
            }
        }
        public string Create(ProductRequest pr)
        {
            var obj = new Product
            {
                Name = pr.Name,
                Description = pr.Description,
                Price = pr.Price,
                DateCreated = DateTime.Now,
                CategoryId = pr.CategoryId,
                AvatarUrl=pr.AvatarUrl
            };
                _db.Product.Add(obj);
                _db.SaveChanges();
                return String.Empty;
            
        }
        
    }
}
