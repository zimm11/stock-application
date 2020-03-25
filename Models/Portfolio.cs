using System;
using System.Collections.Generic;
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
        public string CompanyName { get; set; }
        //public decimal CurrentPrice { get; set; }
        public DateTime? PurchaseDateTime { get; set; }
        public int? AmountOfShares { get; set; }
        public decimal? PricePerShare { get; set; }
        public decimal? TotalPurchasePrice { get; set; }
    }
}
