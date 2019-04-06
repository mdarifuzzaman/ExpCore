using ExpCore.Core;
using ExpCore.Core.Data;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExpCore.Infrastructure.OData
{
    public abstract class BaseReadOnlyODataController<TModel>: ODataServiceController<TModel> where TModel:class, IEntity
    {
        protected virtual IReadOnlyRepository<TModel> Repository { get; }
        protected BaseReadOnlyODataController(IReadOnlyRepository<TModel> repository)
        {
            this.Repository = repository;
        }

        [EnableQuery]
        public virtual async Task<IHttpActionResult> Get()
        {
            return await base.HandleGet<TModel>(() => Repository.GetData());
        }

        [EnableQuery]
        public virtual async Task<IHttpActionResult> Get([FromODataUri] string key)
        {
            return await base.HandleGet<TModel>(key, (id) => Repository.Get(id));
        }
    }
}
