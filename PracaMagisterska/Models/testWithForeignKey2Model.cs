using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracaMagisterska.Models
{
    public class testWithForeignKey
    {
        [Key]
        public int id_agreement_silosy { get; set; }
        public string? nvarcahrRow { get; set; }
        public Decimal? DecimalRow { get; set; }
        public int? IntRow { get; set; }
        public Byte? tinyint { get; set; }
        public int? testIdNr { get; set; }


    }
}
