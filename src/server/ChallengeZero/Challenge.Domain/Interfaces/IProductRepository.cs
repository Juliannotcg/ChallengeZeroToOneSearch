using Challenge.Domain.Models;
using System.Collections.Generic;

namespace Challenge.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllProductsCategories();
        void AddCategory(Category category);
    }
}
