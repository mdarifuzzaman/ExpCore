using ExpCore.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace ExpCore.Infrastructure.Tests
{
    public class ServiceControllerTest
    {
        private readonly MockController _serviceController = new MockController();
        [SetUp]
        public void Setup()
        {
            var actionContext = new ActionContext();
            actionContext.HttpContext = new DefaultHttpContext();
            actionContext.RouteData = new Microsoft.AspNetCore.Routing.RouteData();
            actionContext.ActionDescriptor = new ControllerActionDescriptor();
            _serviceController.ControllerContext = new ControllerContext(actionContext);
        }

        [Test]
        public async Task HandleGetTest()
        {
            var data = await _serviceController.Get(); 
            Assert.NotNull(data.ViewData.Model);
            var model = (data.ViewData.Model as OkObjectResult).Value as EnumerableQuery<TestModel>;
            Assert.AreEqual("001", model.First().Id);
        }

        [Test]
        public async Task HandlePostTest()
        {
            var data = await _serviceController.Post(new TestModel { Id = "002" });
            Assert.NotNull(data.ViewData.Model);
            var statusCode = (data.ViewData.Model as StatusCodeResult);
            Assert.AreEqual(201, statusCode.StatusCode);
        }

        [Test]
        public async Task HandleDeleteTest()
        {
            var data = await _serviceController.Delete("003");
            Assert.NotNull(data.ViewData.Model);
            var statusCode = (data.ViewData.Model as StatusCodeResult);
            Assert.AreEqual(204, statusCode.StatusCode);
        }
    }

    public class TestModel : Entity
    {
    }
}