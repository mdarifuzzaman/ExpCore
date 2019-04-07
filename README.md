# ExpCore 
- Open source library to create your WEB API really easy. Super extensible, scalable, dotnetcore
- Provides two types of repository support, ReadOnly and ReadWrite. You can use readonly repository to make your API only readonly supports

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

### That's it. Since it's support both read and write, that controller is going to support all the CRUD of Customer i.e
1. get(by id):  --    api/customer/1 (HTTPGET)
2. get          --    api/customer (HTTPGET)
2. post         --    api/customer (posted data will be added) (HTTPPOST)
2. delete       --    api/customer?key=1 (HTTPDELETE)
3. update       --    api/customer?key=1 (posted data will be updated) HTTPPUT

### We can change that controller easily like below:
<pre>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : BaseReadOnlyController&lt;Customer&gt;
    {
        public CustomerController(IReadOnlyRepository<Customer> readOnlyRepository) : base(readOnlyRepository)
        {
        }
    }
</pre>

### Since it's support readonly , that controller is going to support all the CRUD of Customer i.e
1. get(by id):  --    api/customer/1 (HTTPGET)
2. get          --    api/customer (HTTPGET)
