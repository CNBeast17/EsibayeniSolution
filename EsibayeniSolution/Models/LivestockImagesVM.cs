using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsibayeniSolution.Models
{
    public class LivestockImagesVM
    {
        [Key]
        public int ImageId { get; set; }
        public string LivestockCode { get; set; }
        public DateTime UploadDate { get; set; }
    }
}