using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ehsproject.Entities
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        public string? SupplierCode { get; set; }
        public string? Pass { get; set; }

    }
}