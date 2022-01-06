using ModelLibrary.Attributes;
using ModelLibrary.Models.Database.Enumerate;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLibrary.Models.Database
{
    [Table(nameof(TReserve))]
    public class TReserve
    {
        [Key]
        public int TReserveId { get; set; }

        public ReserveState State { get; set; }

        [LessThan(nameof(ReserveStart))]
        public DateTime BlockStart { get; set; }

        [GreaterThan(nameof(ReserveEnd))]
        public DateTime BlockEnd { get; set; }

        [LessThan(nameof(ReserveEnd))]
        public DateTime ReserveStart { get; set; }

        [GreaterThan(nameof(ReserveStart))]
        public DateTime ReserveEnd { get; set; }

        //[StringLength(Max)]
        public string ReserveMemo { get; set; }

        [StringLength(200)]
        public string ReserveMemo1 { get; set; }

        [InsertQueryParameter("GetDate()")]
        [UpdateQueryParameter("GetDate()")]
        [Optimist(false)]
        public DateTime Optimist { get; set; }
    }
}
