using ModelLibrary.Attributes;
using ModelLibrary.Models.Database.Enumerate;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLibrary.Models.Database
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(15)]
        public string ShortName { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Memo { get; set; }

        public PriceType PriceType { get; set; }

        public decimal Price { get; set; }

        [Optimist(false)]
        public DateTime Optimist { get; set; }
    }
}
