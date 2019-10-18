using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;
using Challenge.Infra.Data.Context;
using System;

namespace Challenge.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ContextEntity context) 
            : base(context)
        {
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
