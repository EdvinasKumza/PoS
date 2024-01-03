using System;
using System.Collections.Generic;
using System.Linq;
using PoS.Data;
using Microsoft.EntityFrameworkCore;
using PoS.Services.GenericServices;
using WebApplication1.Models;


namespace PoS.Services.ServiceServices
{

    public class ServiceService : GenericService<Service>, IServiceService
    {
        public ServiceService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any additional Service-specific methods, if needed
    }
}
