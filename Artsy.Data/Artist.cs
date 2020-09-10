using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Data
{
    public enum ArtistType
    {
        Painter = 1,
        Photographer,
        Sculptor,
        Calligrapher,
        Printmaker,
        GraphicDesigner,
        Ceramicist

    }
    public class Artist
        //add validation attributes after done testing
    {
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ArtistBio { get; set; }
        
        public ArtistType? ArtistType { get; set; }
        public int? Rating { get; set; }
        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset ModifiedUTC { get; set; }
        public virtual ICollection<Piece> Pieces { get; set; }
    }
}
