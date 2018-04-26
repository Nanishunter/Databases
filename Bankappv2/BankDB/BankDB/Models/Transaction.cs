using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDB.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
        }

        public long Id { get; set; }
        [Required]
        [Column("IBAN", TypeName = "nchar(10)")]
        public string Iban { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime TimeStamp { get; set; }

        [ForeignKey("Iban")]
        [InverseProperty("Transaction")]
        public Account IbanNavigation { get; set; }
    }
}
