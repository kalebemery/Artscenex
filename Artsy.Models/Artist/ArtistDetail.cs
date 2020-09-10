using Artsy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class ArtistDetail
    {
        [Display(Name = "Artist Id")]
        public int ArtistId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Artist Bio")]
        public string ArtistBio { get; set; }
        [Display(Name = "Artist Type")]
        public ArtistType? ArtistType { get; set; }
        public int? Rating { get; set; }
        [Display(Name = "Account Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name = "Account Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
        public List<Piece> Pieces { get; set; }
        
    }
}

//get an artist by ID
