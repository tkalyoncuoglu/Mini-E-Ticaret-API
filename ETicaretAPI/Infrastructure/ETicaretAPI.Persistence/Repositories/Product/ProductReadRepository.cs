using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }

        public object GetProducts(int skip, int take)
        {
            var products = Table.AsQueryable().AsNoTracking().Skip(skip).Take(take)
            .Include(p => p.ProductImageFiles)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                    p.CreatedDate,
                    p.UpdatedDate,
                    p.ProductImageFiles
                }).ToList();

            return products;

        }
    }
}
