using ExpCore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExCore.Sample.EF.Models
{
    public class Order: Entity
    {
        public string OrderName { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OrderTotal { get; set; }
        public ICollection<OrderLine> Lines { get; set; }
    }
}
