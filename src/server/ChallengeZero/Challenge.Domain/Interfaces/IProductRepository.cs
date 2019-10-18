using Challenge.Domain.Models;

namespace Challenge.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void AddCategory(Category category);
    }
}
