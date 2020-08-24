using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public double PiecePrice { get; set; }
        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey(nameof(Piece))]
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
    }
}
