using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EsibayeniSolution.Models
{
    public class BatchCategory
    {
        public int BatchCategoryID { get; set; }

        [DisplayName("Type")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}