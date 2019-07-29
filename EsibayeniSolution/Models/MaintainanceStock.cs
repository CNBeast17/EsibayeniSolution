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
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int PCatID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public string ProductType { get; set; }
        public DateTime dateOfEntry { get; set; }
        public DateTime Expirydate { get; set; }

        public double StockPrice { get; set; }

    }
}