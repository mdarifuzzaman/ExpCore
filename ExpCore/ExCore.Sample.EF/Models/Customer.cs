using ExpCore.Core;
using ExpCore.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExCore.Sample.EF.Models
{
    public class Customer: Entity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
