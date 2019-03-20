using SimpleCRUD.Data.Abstract;
using SimpleCRUD.Model.Entities;

namespace SimpleCRUD.Data.Repositories
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context: context) { }
    }
}
