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
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey(nameof(Piece))]
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
        public DateTime CreatedUTC { get; set; }
        public double PiecePrice { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}


//Is it necessary to have these as foreign keys? what are the advantages of having a foreign key as opposed to just referencing it from the
//piece and customer class

//public class Transaction
//{
//    [Key]
//    public int PieceId { get; set; }
//    
//    [ForeignKey(nameof(Customer))]
//    public int CustomerId { get; set; }
//    public Customer Customer { get; set; }

//    [Required]
//    [ForeignKey(nameof(Piece))]
//    public int PieceId { get; set; }
//    public Piece Piece { get; set; }
//}