using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracaMagisterska.Models
{
    public class tests
    {
        [Key]
        public int id_order { get; set; }
        public string? sent_to_sap_id_package { get; set; }
        public string? ordr_docentry { get; set; }
        public int? state { get; set; }
        public string? CardCode { get; set; }
        public DateTime? create_date { get; set; }
        public string? customer_order_number { get; set; }
        public Decimal? total_netto_price { get; set; }
        public Decimal? total_brutto_price { get; set; }
        public int? payment_type_code { get; set; }
        public string? pdf_filename { get; set; }
        public string? order_attention { get; set; }
        public string? invoice_pdf_filename { get; set; }
        public int? user_id { get; set; }
        public int? id_joined_order { get; set; }
        public DateTime? atc_mail_date { get; set; }
        public string? dtwShipFromDirect { get; set; }
        public string? mirror_done { get; set; }
        public string? order_spectype { get; set; }
        public DateTime? last_modified_date { get; set; }
        public int? skonto_percent { get; set; }
        public Decimal? skonto_value { get; set; }
        public Byte? order_pickuptype { get; set; }
        public string? dealer_billto_cardcode { get; set; }
        public string? dealer_shipto_cardcode { get; set; }

        public Byte? logistic_minimums_valid { get; set; }
        public string? logistic_minimums_error { get; set; }

    }
}
