using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApplication.Models
{
    public class Portfolio
    {
        [Key][Required]
        public int ID { get; set; }
        public virtual AppUser AppUser { get; set; }
        [Required] 
        public string Symbol { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        //public decimal CurrentPrice { get; set; }
        [DisplayName("Purchase Date / Time")]
        public DateTime? PurchaseDateTime { get; set; }
        [DisplayName("Number of Shares")]
        public int? AmountOfShares { get; set; }
        [DisplayName("Purchase Price Per Share")]
        public decimal? PricePerShare { get; set; }
    }
}
