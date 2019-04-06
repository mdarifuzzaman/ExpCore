using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpCore.Core;
using ExpCore.Core.Data;
using ExpCore.Infrastructure.OData;
using ExpCore.ListRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : BaseReadWriteODataController<Employee>
    {
        public EmployeeController(IReadOnlyRepository<Employee> readOnlyRepository, IReadWriteRepository<Employee> repository) : base(readOnlyRepository, repository)
        {
        }
    }
}