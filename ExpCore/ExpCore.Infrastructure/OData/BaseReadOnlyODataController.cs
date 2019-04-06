using ExpCore.Core;
using ExpCore.Core.Attribute;
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
        [QueryStringConstraint("id", true)]
        public virtual async Task<IHttpActionResult> Get([FromODataUri] string id)
        {
            return await base.HandleGet<TModel>(id, (key) => Repository.Get(id));
        }
    }
}
