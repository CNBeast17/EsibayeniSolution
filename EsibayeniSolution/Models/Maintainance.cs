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
        [DisplayName("Groomer")]
        public string User { get; set; }

        [DisplayName("Livestock Code")]
        public int LivestockID { get; set; }
        public virtual LivesStock LivesStock { get; set; }
        [DisplayName("Product Name")]
        public int ProductId { get; set; } 
        public virtual MaintainanceStock MaitainanceStock { get; set; }
        [DisplayName("Product Category")]
        public string ProductCategory { get; set; }
        public int MainPId { get; set; }
        public virtual MaintainanceProcess MaintainanceProcess { get; set; }
        [DisplayName("Date of attendance")]
        public DateTime AttendanceDate { get; set; }
        [DisplayName("Previous date attended in")]
        public DateTime PreviousDate { get; set; }
        [DisplayName("Previous weight")]
        public decimal PreviousWeight { get; set; }
        [DisplayName("Current weight")]
        public decimal CurrentWeight { get; set; }



        public DateTime DateTimeNow()
        {
            return DateTime.Now;
        }


    }
}