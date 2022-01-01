using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelLibrary.Models.Database
{
    [Table(nameof(FilureReason))]
    public class FilureReason
    {
        [Key]
        public int FilureReasonId { get; set; }
    }
}
