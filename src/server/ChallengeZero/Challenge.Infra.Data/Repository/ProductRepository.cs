using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;
using Challenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Product> GetAllProductsCategories()
        {
            return Db.Products.Include(c => c.Category).ToList();
        }
    }
}
