using Artsy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class PieceCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public PieceType? PieceType { get; set; }
        [Required]
        public int ArtistId { get; set; }
    }
}
