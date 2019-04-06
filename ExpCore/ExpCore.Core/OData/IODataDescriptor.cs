using ExpCore.Core.OData.Edm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpCore.Core.OData
{
    public interface IODataDescriptor
    {
        IEdmModelBuilder ModelBuilder { get; }
        string RouteName { get; }
        string RoutePrefix { get; }
    }
}
