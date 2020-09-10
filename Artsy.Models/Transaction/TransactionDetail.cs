using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models.Transaction
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }

        public double PiecePrice { get; set; }
        public int CustomerId { get; set; }
        public int PieceId { get; set; }
        public DateTime CreatedUTC { get; set; }

    }
}
