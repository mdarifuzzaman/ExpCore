using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.Core.Data
{
    public interface IReadOnlyRepository<TModel> where TModel: class, IEntity
    {
        Task<TModel> Get(string id);
        Task<IQueryable<TModel>> GetData();
    }
}
