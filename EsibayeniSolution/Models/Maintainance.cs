using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsibayeniSolution.Models
{
    public class Maintainance
    {
        [Key]
        public int MProcID { get; set; }

        [DisplayName("Livestock Code")]
        public int LivestockID { get; set; }
        public virtual LivesStock LivesStock { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public int PCatID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public int MainPId { get; set; }
        public virtual MaintainanceProcess MaintainanceProcess { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of attendance")]
        public DateTime Date { get; set; }
        [DisplayName("Previous date attended in")]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }
        [DisplayName("Previous weight")]
        public decimal PreiviousWeight { get; set; }
        [DisplayName("Current weight")]
        public decimal CurrentWeight { get; set; }
       
        
       
    }
}