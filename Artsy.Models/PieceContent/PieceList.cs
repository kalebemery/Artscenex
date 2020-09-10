using Artsy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class PieceList
    {
        [Display(Name = "Piece Id")]
        public int PieceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public PieceType? PieceType { get; set; }
        [Display(Name = "Artist Id")]
        public int ArtistId { get; set; }


    }
}
