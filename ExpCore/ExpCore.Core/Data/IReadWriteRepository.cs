using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.Core.Data
{
    public interface IReadWriteRepository<TModel>: IReadOnlyRepository<TModel> where TModel:class, IEntity
    {
        Task Add(TModel entity);

        Task Delete(TModel entity);

        Task Update(TModel entity);

        Task<bool> Exists(string id);
    }
}
