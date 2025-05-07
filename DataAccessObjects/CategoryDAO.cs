using BusinessObjects;

namespace DataAccessObjects
{
    public class CategoryDAO
    {
        private readonly MyStoreContext _context;

        public CategoryDAO(MyStoreContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
