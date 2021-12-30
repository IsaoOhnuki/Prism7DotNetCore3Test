using LogicCommonLibrary.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBMaigration
{
    public class Table1
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [UpdateQueryParameter("GetDate()")]
        [InsertQueryParameter("GetDate()")]
        [Optimist(false)]
        [MaxLength(8)]
        public DateTime Optimist { get; set; }
    }
}
