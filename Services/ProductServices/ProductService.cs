using System;
using System.Collections.Generic;
using System.Linq;
using PoS.Data;
using Microsoft.EntityFrameworkCore;
using PoS.Services.GenericServices;
using WebApplication1.Models;


namespace PoS.Services.ProductServices
{

    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any additional Product-specific methods, if needed
    }
}
