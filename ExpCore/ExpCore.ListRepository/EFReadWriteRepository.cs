using ExCore.Sample.EF;
using ExpCore.Core;
using ExpCore.Core.Data;
using ExpCore.ExpCore.Sample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.ExpCore.Sample.Repository
{
    public class EFReadWriteRepository<TModel> : EFReadOnlyRepository<TModel>, IReadWriteRepository<TModel> where TModel : class, IEntity
    {
        private readonly CustomerOrderContext _customerOrderContext;
        public EFReadWriteRepository(CustomerOrderContext context):base(context)
        {
            _customerOrderContext = context;
        }

        public async Task Add(TModel entity)
        {
            await _customerOrderContext.AddAsync<TModel>(entity);
            await _customerOrderContext.SaveChangesAsync();
        }

        public async Task Delete(TModel entity)
        {
            _customerOrderContext.Remove<IEntity>(entity);
            await _customerOrderContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(string id)
        {
            var entity = await _customerOrderContext.FindAsync<TModel>(id);
            return entity != null;
        }

        public async Task Update(TModel entity)
        {
            _customerOrderContext.Update<TModel>(entity);
            await _customerOrderContext.SaveChangesAsync();
        }
    }
}
