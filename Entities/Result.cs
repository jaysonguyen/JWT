using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ehsproject.Entities
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public int? ResultId { get; set; }

        public string? NameMaker { get; set; }

        public bool? IsContain { get; set; }

        public string? SupplierCode { get; set; }
    }
}