using ExCore.Sample.EF;
using ExpCore.Core;
using ExpCore.Core.Data;
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
            var stored = await _customerOrderContext.FindAsync<TModel>(entity.Id);
            if (stored == null)
            {
                return;
            }

            _customerOrderContext.Entry(stored).CurrentValues.SetValues(entity);
            await _customerOrderContext.SaveChangesAsync();
        }
    }
}
