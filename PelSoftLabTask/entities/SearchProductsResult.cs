﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PelSoftLabTask.entities
{
    public partial class SearchProductsResult
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? price { get; set; }
        public DateTime? MfgDate { get; set; }
        public string Category { get; set; }
    }
}
