using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models.Transaction
{
    public class TransactionDetail
    {
        [Display(Name = "Transaction Id:")]
        public int TransactionId { get; set; }
        [Display(Name = "Price:")]
        public double PiecePrice { get; set; }
        [Display(Name = "Customer Id:")]
        public int CustomerId { get; set; }
        [Display(Name = "Art Piece Id:")]
        public int PieceId { get; set; }
        [Display(Name = "Purchase Made:")]
        public DateTime CreatedUTC { get; set; }

    }
}
