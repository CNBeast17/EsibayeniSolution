﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsibayeniSolution.Models
{
    public class ProductCategory
    {
        [Key]
        public int PCatID { get; set; }

       
        public string ProductType { get; set; }
    }
}