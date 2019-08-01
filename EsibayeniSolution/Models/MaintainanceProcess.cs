using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsibayeniSolution.Models
{
    public class MaintainanceProcess
    {
        [Key]
        public int MainPId { get; set; }
        public string MainName { get; set; }

    }
}