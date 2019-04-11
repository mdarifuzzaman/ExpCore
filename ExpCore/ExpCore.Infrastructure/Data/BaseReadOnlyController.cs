using ExpCore.Core;
using ExpCore.Core.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.Infrastructure.Data
{
    public abstract class BaseReadOnlyController<TModel>: ServiceController<TModel> where TModel:class, IEntity
    {
        protected virtual IReadOnlyRepository<TModel> Repository { get; }
        protected BaseReadOnlyController(IReadOnlyRepository<TModel> repository)
        {
            this.Repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult> Get()
        {
            return await base.HandleGet<TModel>(() => Repository.GetData());
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult> Get(string id)
        {
            return await base.HandleGet<TModel>(id, (key) => Repository.Get(id));
        }
    }
}
