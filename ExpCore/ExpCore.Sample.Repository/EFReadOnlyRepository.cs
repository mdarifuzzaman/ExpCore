using ExCore.Sample.EF;
using ExpCore.Core;
using ExpCore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.ExpCore.Sample.Repository
{
    public class EFReadOnlyRepository<TModel> : IReadOnlyRepository<TModel> where TModel : class, IEntity
    {
        private readonly CustomerOrderContext _customerOrderContext;
        public EFReadOnlyRepository(CustomerOrderContext context)
        {
            _customerOrderContext = context;
        }

        public async Task<TModel> Get(string id)
        {
            var model = _customerOrderContext.Find<TModel>(id);
            return await Task.FromResult(model);
        }

        public async Task<IQueryable<TModel>> GetData()
        {
            var model = _customerOrderContext.Set<TModel>();
            return await Task.FromResult(model.AsQueryable());
        }
    }
}
