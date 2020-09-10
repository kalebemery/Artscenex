using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models.Transaction
{
    public class TransactionCreate
    {
        [Required]
        public int CustomerId { get; set; }
        public int PieceId { get; set; }
        public double PiecePrice { get; set; }


    }
}
