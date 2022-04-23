using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracaMagisterska.Models
{
    public class TS_price_PRICELIST_ACTIONS
    {
        [Key]
        public int action_id { get; set; }
        public string action_name { get; set; }
        public Byte shown_before_acceptence { get; set; }
        public int shown_on_accept_screen { get; set; }
        public int shown_on_general { get; set; }

    }
}
