using System;
using System.Collections.Generic;
using System.Text;

namespace ExpCore.Core.OData.Edm
{
    public class EntitySetDefinition
    {
        private readonly Type _type;
        private readonly string _collectionName;
        public EntitySetDefinition(Type type)
        {
            this._type = type;
        }

        public EntitySetDefinition(Type type, string collectionName):this(type)
        {
            this._collectionName = collectionName;
        }
        public Type Type => this._type;
        public string CollectionName => this._collectionName;
    }
}
