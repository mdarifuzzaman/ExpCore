using ExpCore.Core;
using ExpCore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.ListRepository
{
    public class ListReadWriteRepository<TModel> : ListReadOnlyRepository<TModel>, IReadWriteRepository<TModel> where TModel : class, IEntity
    {
        public ListReadWriteRepository() : base()
        {
        }

        public async Task Add(TModel entity)
        {
            database.Add<TModel>(entity);
            await Task.FromResult<TModel>(null);
        }

        public async Task Delete(TModel entity)
        {
            database.Delete<TModel>(entity);
            await Task.FromResult<TModel>(null);
        }

        public async Task<bool> Exists(string id)
        {
            return await Task.FromResult(database.Exists(id));
        }
        
        public async Task Update(TModel entity)
        {
            database.Update<TModel>(entity);
            await Task.FromResult<TModel>(null);
        }
    }
}
