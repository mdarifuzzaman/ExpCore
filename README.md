# ExpCore

## Technology: AspNetCore, Fully Extensible
## Sample is provided using EF Core
## Going to support swagger very soon

Web API made easy using ExpCore. Keeping in mind about different CRUD with different APIs, ExpCore simplifies all.

## Repositories of ExpCore are divided into two parts

1. ReadOnly
2. ReadWrite

## How Easy?
Well, Just add references "ExpCore.Core" and "ExpCore.Infrastructure"
Now, Add a controller like below and that's it !!!

<pre>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : BaseReadWriteController&lt;Customer&gt;
    {
        public CustomerController(IReadWriteRepository<Customer> readWriteRepository) : base(readWriteRepository)
        {
        }
    }
</pre>

### That's it. That controller is going to support all the CRUD of Customer i.e
1. get(by id):  --    api/customer/1 (HTTPGET)
2. get          --    api/customer (HTTPGET)
2. post         --    api/customer (posted data will be added) (HTTPPOST)
2. delete       --    api/customer?key=1 (HTTPDELETE)
3. update       --    api/customer?key=1 (posted data will be updated) HTTPPUT
