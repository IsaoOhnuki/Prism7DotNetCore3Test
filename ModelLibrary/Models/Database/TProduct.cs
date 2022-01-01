using ModelLibrary.Attributes;
using ModelLibrary.Models.Database.Enumerate;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLibrary.Models.Database
{
    [Table(nameof(TProduct))]
    public class TProduct
    {
        [Key]
        public int TProductId { get; set; }

        public int TReserveId { get; set; }

        public int MProductId { get; set; }

        [StringLength(15)]
        public string ProductShortName { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string ProductMemo { get; set; }

        public PriceType ProductPriceType { get; set; }

        public decimal ProductPrice { get; set; }

        [InsertQueryParameter("GetDate()")]
        [UpdateQueryParameter("GetDate()")]
        [Optimist(false)]
        public DateTime Optimist { get; set; }
    }
}
