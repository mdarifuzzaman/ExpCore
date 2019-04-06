using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpCore.Core.OData.Edm
{
    public interface IEdmModelBuilder
    {
        IEdmModel GetEdmModel();
    }
}
