using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ehsproject.Entities
{
    [Table("FovRequest")]
    public class FovRequest
    {
        [Key]
        public int? FovRequestID { get; set; }
        public string? RequestNo { get; set; }

        [JsonIgnore]
        public int? Count { get; set; } = 0; 
        public string? Status { get; set; }
        public string? Spec { get; set; }
        public string? Require { get; set; }
        public string? SupplierCode { get; set; }
    }
}