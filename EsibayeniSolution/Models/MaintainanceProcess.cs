using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsibayeniSolution.Models
{
    public class MaintainanceProcess
    {
        [Key]
        public int MProcID { get; set; }
        public virtual LivesStock LivesStock { get; set; }

        public int LivestockID { get; set; }

        public DateTime date { get; set; }

        public DateTime time { get; set; }
    }
}