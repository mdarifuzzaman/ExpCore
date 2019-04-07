using ExpCore.Core;
using ExpCore.Core.Data;
using ExpCore.Infrastructure.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExpCore.Infrastructure.Data
{
    public abstract class BaseReadWriteController<TModel> : BaseReadOnlyController<TModel> where TModel : class, IEntity
    {
        private readonly IReadWriteRepository<TModel> _repository;
        protected BaseReadWriteController(IReadWriteRepository<TModel> repository) : base(repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<ActionResult> Post([FromBody] TModel entity)
        {
            return await base.HandlePost(entity, (id) => _repository.Exists(id), (model) => _repository.Add(model));
        }

        [HttpPut]
        [ValidateModelState]
        public async Task<ActionResult> Put(string key, [FromBody] TModel update)
        {
            return await base.HandlePut(key, update, id => _repository.Exists(id), model => _repository.Update(update));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string key)
        {
            return await base.HandleDelete(key, id => _repository.Get(id), model => _repository.Delete(model));
        }
    }
}
