using ExpCore.Core;
using ExpCore.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.Infrastructure.Data
{
    public abstract class ServiceController<TModel> : Controller, IServiceController where TModel : class, IEntity
    {
        protected ServiceController() { }

        protected virtual async Task<ActionResult> HandleGet<T>(Func<Task<IQueryable<T>>> getEntitiesFunc)
        {
            return Ok(await getEntitiesFunc());
        }

        protected virtual async Task<ActionResult> HandleGet<T>(string id, Func<string, Task<T>> getEntityFunc) where T : IEntity
        {
            return Ok(await getEntityFunc(id));
        }

        protected virtual async Task<ActionResult> HandlePost(TModel entity, Func<string, Task<bool>> entityExistsFunc, Func<TModel, Task> addEntityFunc)
        {
            if (Entity.HasIdentity(entity))
            {
                var exists = await entityExistsFunc(entity.Id);
                if (!exists)
                {
                    await addEntityFunc(entity);
                    return StatusCode(201);
                }
            }
            return BadRequest();
        }
        protected virtual async Task<ActionResult> HandlePut(string key, TModel entity, Func<string, Task<bool>> entityExistsFunc, Func<TModel, Task> updateEntityFunc)
        {
            if (!Entity.HasIdentity(entity))
            {
                return BadRequest("Missing model id");
            }

            if (string.IsNullOrEmpty(key))
            {
                return BadRequest("Missing key");
            }

            if (entity.Id != key)
            {
                return BadRequest("given id and model id missmatch");
            }

            var exists = await entityExistsFunc(entity.Id);
            if (!exists)
            {
                return NotFound();
            }

            await updateEntityFunc(entity);

            return StatusCode(201);
        }

        protected virtual async Task<ActionResult> HandleDelete(string key, Func<string, Task<TModel>> getEntityFunc, Func<TModel, Task> deleteEntityFunc)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest("Missing key");
            }

            var entity = await getEntityFunc(key);

            if(entity == null)
            {
                return NotFound();
            }

            await deleteEntityFunc(entity);

            return StatusCode(204);
        }
    }
}
