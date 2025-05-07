using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        private readonly MyStoreContext _context;

        public ProductDAO(MyStoreContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        }

        public void SaveProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product p)
        {
            _context.Products.Update(p);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            _context.Products.Remove(p);
            _context.SaveChanges();
        }
    }
}
