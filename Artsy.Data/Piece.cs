using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Data
{
    public enum PieceType
    {
        Photography = 1,
        Painting,
        Sculpture,
        Prints,
        Textile,
        Ceramic,
        Calligraphy,
        Other
    }
    public class Piece
    {
        [Key]
        public int PieceId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public PieceType? PieceType { get; set; }
        [Required]
        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
