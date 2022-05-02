using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracaMagisterska.Models
{
    public class testWithForeignKey2
    {
        [Key]
        public string nvarcharColumn { get; set; }
        public DateTime? Data { get; set; }
        public string? nvarchar10 { get; set; }
        public DateTime? date2 { get; set; }
        public Decimal? decimalColumn1 { get; set; }
        public int? testsWithForeignKeyid { get; set; }


    }
  
}
