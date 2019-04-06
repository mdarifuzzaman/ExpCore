using ExpCore.Core;
using ExpCore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.ListRepository
{
    public class ListReadOnlyRepository<TModel> : IReadOnlyRepository<TModel> where TModel:class, IEntity
    {
        protected readonly Database database = new Database();
        public async Task<TModel> Get(string id)
        {
            var employee = database.GetData<TModel>().SingleOrDefault(e => e.Id == id);
            return await Task.FromResult(employee);
        }

        public async Task<IQueryable<TModel>> GetData()
        {
            var data = database.GetData<TModel>().AsQueryable<TModel>();
            return await Task.FromResult(data);
        }
    }
}
