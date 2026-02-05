using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class ProductRepository :IProductRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment  _webhostEnvironment;

        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment webhostEnvironment)
        {
            _db = db;
            _webhostEnvironment = webhostEnvironment;
        }

        public async Task<Product> CreateAsync(Product obj)
        {
            _db.Product.Add(obj);
            _db.SaveChanges();
            return obj;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var obj = _db.Product.FirstOrDefault(u => u.Id == id);
            var imagePath = Path.Combine(_webhostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('/'));
            if(File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            if (obj != null)
            {
                _db.Product.Remove(obj);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public async Task<Product> GetAsync(int id)
        {
            var obj = _db.Product.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return new Product();
            }
            return obj;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return  await _db.Product.Include(u=>u.Category).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            var objFromDb = _db.Product.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.ImageUrl = obj.ImageUrl;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Price = obj.Price;
                _db.Product.Update(objFromDb);
                _db.SaveChanges();
                return objFromDb;
            }
            return obj;

        }



















    }
}
