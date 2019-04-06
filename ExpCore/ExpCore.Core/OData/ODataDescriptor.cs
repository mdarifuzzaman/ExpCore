using System;
using ExpCore.Core.OData.Edm;

namespace ExpCore.Core.OData
{
    public abstract class ODataDescriptor : IODataDescriptor
    {
        private readonly string _routeName;
        private readonly string _routePrefix;
        private readonly IEdmModelBuilder _modelBuilder;

        protected ODataDescriptor(string routeName, string routePrefix, IEdmModelBuilder modelBuilder)
        {
            this._routeName = routeName ?? throw new ArgumentNullException(nameof(routeName));
            this._routePrefix = routePrefix ?? throw new ArgumentNullException(nameof(routePrefix));
            this._modelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));
        }
        public IEdmModelBuilder ModelBuilder => this._modelBuilder;

        public string RouteName => this._routeName;

        public string RoutePrefix => "api/odata/" + this._routePrefix;
    }
}
