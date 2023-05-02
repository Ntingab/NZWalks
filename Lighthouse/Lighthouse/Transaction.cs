using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lighthouse
{
    public class Transaction
    {
        [Key]
        public int TrancationID { get; set; }

        [Required]
        public string BeneficiaryName { get; set; }
        [Required]

        public string BankName { get; set; }

        [Required]
        public string AccountType { get; set;}

        [Required]
        public string AccountNumber { get; set; }
    }
}
