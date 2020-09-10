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
        [Display(Name = "Customer Id:")]
        public int CustomerId { get; set; }
        [Display(Name = "Piece Id:")]
        public int PieceId { get; set; }
        [Display(Name = "Price:")]
        public double PiecePrice { get; set; }


    }
}
