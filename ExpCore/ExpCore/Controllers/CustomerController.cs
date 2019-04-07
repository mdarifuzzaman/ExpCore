using ExCore.Sample.EF.Models;
using ExpCore.Core.Data;
using ExpCore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExpCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : BaseReadWriteController<Customer>
    {
        public CustomerController(IReadWriteRepository<Customer> readWriteRepository) : base(readWriteRepository)
        {
        }
    }
}