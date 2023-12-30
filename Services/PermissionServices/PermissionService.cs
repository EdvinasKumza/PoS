using System;
using System.Collections.Generic;
using System.Linq;
using PoS.Data;
using Microsoft.EntityFrameworkCore;
using PoS.Services.GenericServices;
using WebApplication1.Models;


namespace PoS.Services.PermissionServices
{

    public class PermissionService : GenericService<Permission>, IPermissionService
    {
        public PermissionService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any additional Permission-specific methods, if needed
    }
}
