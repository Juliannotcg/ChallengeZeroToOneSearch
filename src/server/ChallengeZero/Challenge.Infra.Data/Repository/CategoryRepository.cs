using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;
using Challenge.Infra.Data.Context;

namespace Challenge.Infra.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ContextEntity context) : base(context)
        {
        }
    }
}
