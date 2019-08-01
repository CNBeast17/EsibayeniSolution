using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsibayeniSolution.Models
{
    public class MaintainanceStock
    {
        [Key]
        [DisplayName("Product ID")]
        public int ProductID { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Product Category")]
        public int PCatID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public DateTime dateOfEntry { get; set; }
        public DateTime Expirydate { get; set; }
        [DisplayName("Cost Price")]
        public double StockPrice { get; set; }

        public DateTime EntryDate()
        {
            return DateTime.Now;
        }

    }
}