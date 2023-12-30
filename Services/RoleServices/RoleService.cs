using System;
using System.Collections.Generic;
using System.Linq;
using PoS.Data;
using Microsoft.EntityFrameworkCore;
using PoS.Services.GenericServices;
using WebApplication1.Models;


namespace PoS.Services.RoleServices
{

    public class RoleService : GenericService<Role>, IRoleService
    {
        public RoleService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any additional Role-specific methods, if needed
    }
}
