using System;
using System.Collections.Generic;
using System.Text;

namespace ExpCore.Core
{
    public interface IEntity
    {
        string Id { get; }
        bool HasIdentity();
    }
}
