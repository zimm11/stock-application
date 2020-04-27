using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockApplication.Models
{
    public class PortfolioIndexViewModel : Portfolio
    {
        private Portfolio stock;

        public PortfolioIndexViewModel(Portfolio stock)
        {
            this.ID = stock.ID;
            this.Symbol = stock.Symbol;
            this.CompanyName = stock.CompanyName;
            this.PurchaseDateTime = stock.PurchaseDateTime;
            this.AmountOfShares = stock.AmountOfShares;
            this.PricePerShare = stock.PricePerShare;
            this.TotalPurchasePrice = stock.TotalPurchasePrice;
        }

        [DisplayName("Current Price Per Share")]
        public decimal? CurrentPrice { get; set; }
    }
}
