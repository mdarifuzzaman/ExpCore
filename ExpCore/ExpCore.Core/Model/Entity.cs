using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpCore.Core.Model
{
    public abstract class Entity : IEntity
    {
        [Key]
        public string Id { get; set; }

        public bool HasIdentity()
        {
            return !string.IsNullOrEmpty(Id);
        }

        public static bool HasIdentity(IEntity entity)
        {
            return !string.IsNullOrEmpty(entity.Id);
        }
    }
}
