using ExpCore.Core;
using ExpCore.Core.Data;
using ExpCore.Infrastructure.Filter;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExpCore.Infrastructure.OData
{
    public abstract class BaseReadWriteODataController<TModel> : BaseReadOnlyODataController<TModel> where TModel : class, IEntity
    {
        private readonly IReadWriteRepository<TModel> _repository;
        protected BaseReadWriteODataController(IReadOnlyRepository<TModel> readOnlyRepository, IReadWriteRepository<TModel> repository) : base(readOnlyRepository)
        {
            this._repository = repository;
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IHttpActionResult> Post([FromBody] TModel entity)
        {
            return await base.HandlePost(entity, (id) => _repository.Exists(id), (model) => _repository.Add(model));
        }

        [HttpPut]
        [ValidateModelState]
        public async Task<IHttpActionResult> Put([FromODataUri] string key, [FromBody] TModel update)
        {
            return await base.HandlePut(key, update, id => _repository.Exists(id), model => _repository.Update(update));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            return await base.HandleDelete(key, id => _repository.Get(id), model => _repository.Delete(model));
        }
    }
}
