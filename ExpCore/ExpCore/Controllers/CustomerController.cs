using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExCore.Sample.EF.Models;
using ExpCore.Core;
using ExpCore.Core.Data;
using ExpCore.Infrastructure.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CustomerController : BaseReadWriteODataController<Customer>
    {
        public CustomerController(IReadOnlyRepository<Customer> readOnlyRepository, IReadWriteRepository<Customer> readWriteRepository) : base(readOnlyRepository, readWriteRepository)
        {
        }
    }
}