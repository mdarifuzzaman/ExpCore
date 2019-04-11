using ExpCore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpCore.Infrastructure.Tests
{
    public class MockController: ServiceController<TestModel>
    {
        [HttpGet]
        public async Task<ViewResult> Get()
        {
            var response = await base.HandleGet<TestModel>( () =>
            {
                var data = new List<TestModel> { new TestModel { Id = "001" } };
                return Task.FromResult(data.AsQueryable());
            });

            return View(response);
        }

        [HttpPost]
        public async Task<ViewResult> Post(TestModel model)
        {
            var response = await base.HandlePost(model, e=> Task.FromResult(false), m =>
            {
                var data = new List<TestModel> { new TestModel { Id = "001" } };
                return Task.FromResult(data.AsQueryable());
            });

            return View(response);
        }

        [HttpDelete]
        public async Task<ViewResult> Delete(string key)
        {
            var response = await base.HandleDelete(key, (k) => Task.FromResult(new TestModel { Id = key}), m =>
            {
                var data = new List<TestModel> { new TestModel { Id = key } };
                return Task.FromResult(data.AsQueryable());
            });

            return View(response);
        }
    }
}
