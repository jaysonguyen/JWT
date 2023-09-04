using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ehsproject.Entities
{
    [Table("ResultDetail")]
    public class ResultDetail
    {
        [Key]
        public int? DetailID { get; set; }
        public int? ResultId { get; set; }
        public string? Mineral { get; set; }

        public string? Substance { get; set; }
        public string? Concentration { get; set; }

    }
}