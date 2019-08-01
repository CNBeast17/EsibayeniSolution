using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsibayeniSolution.Models
{
    public class LivestockMaintainanceStock
    {
        [Key]
        public int LivestockMaintainanceStockID { get; set; }
        [DisplayName("Livestock Type")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [DisplayName("Product Type")]
        public int ProductID { get; set; }
        public virtual MaintainanceStock MaintainaceStock { get; set; }
    }
}