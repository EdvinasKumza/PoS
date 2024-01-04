﻿using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.CustomerService;

public class CustomerService : GenericService<Customer>, ICustomerService
{
    public CustomerService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}