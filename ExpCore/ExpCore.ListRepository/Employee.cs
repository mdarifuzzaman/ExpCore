using ExpCore.Core;
using ExpCore.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpCore.ListRepository
{
    public class Employee: Entity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
    }
}
