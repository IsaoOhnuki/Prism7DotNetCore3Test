using ModelLibrary.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLibrary.Models.Database
{
    [Table(nameof(TCustomer))]
    public class TCustomer
    {
        [Key]
        public int TCustomerId { get; set; }

        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        //[StringLength(Max)]
        public string CustomerMemo { get; set; }

        [StringLength(200)]
        public string CustomerMemo1 { get; set; }

        [InsertQueryParameter("GetDate()")]
        [UpdateQueryParameter("GetDate()")]
        [Optimist(false)]
        public DateTime Optimist { get; set; }
    }
}
