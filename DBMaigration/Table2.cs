using ModelLibrary.Attributes;
using ModelLibrary.Models.Database.Enumerate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBMaigration
{
    public class Table2
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

        [Required]
        [UpdateQueryParameter("GetDate()")]
        [InsertQueryParameter("GetDate()")]
        [Optimist(false)]
        public DateTime Optimist { get; set; }
    }
}
