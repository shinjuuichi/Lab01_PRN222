using BusinessObjects;
using DataAccessObjects;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO;

        public ProductRepository(ProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public List<Product> GetProducts() => _productDAO.GetProducts();
        public Product GetProductById(int id) => _productDAO.GetProductById(id);
        public void SaveProduct(Product p) => _productDAO.SaveProduct(p);
        public void UpdateProduct(Product p) => _productDAO.UpdateProduct(p);
        public void DeleteProduct(Product p) => _productDAO.DeleteProduct(p);
    }
}
