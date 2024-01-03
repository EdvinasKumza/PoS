using System;
using System.Collections.Generic;
using System.Linq;
using PoS.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using PoS.Services.GenericServices;

namespace PoS.Services.TenantServices
{
    public class TenantService : GenericService<Tenant>, ITenantService
    {
        public TenantService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any additional Tenant-specific methods, if needed
    }
}
