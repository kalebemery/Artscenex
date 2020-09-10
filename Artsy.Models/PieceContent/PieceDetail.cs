using Artsy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class PieceDetail
    {
        [Display(Name = "Piece Id")]
        public int PieceId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public PieceType? PieceType { get; set; }
        [Display(Name = "Artist Id")]
        public int ArtistId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

    }
}
