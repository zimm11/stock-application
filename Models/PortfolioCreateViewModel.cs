using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApplication.Models
{
    public class PortfolioCreateViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Symbol { get; set; }
        [DisplayName("Purchase Date / Time")]
        public DateTime? PurchaseDateTime { get; set; }
        [DisplayName("Number of Shares")]
        public int? AmountOfShares { get; set; }
        [DisplayName("Purchase Price Per Share")]
        public decimal? PricePerShare { get; set; }
    }
}
