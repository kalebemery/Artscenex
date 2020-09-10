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
        [Display(Name = "Description")]
        public string Desc { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        [Display(Name = "Type of Art")]
        public PieceType? PieceType { get; set; }
        [Required]
        [Display(Name = "Artist Id")]
        public int ArtistId { get; set; }
    }
}
