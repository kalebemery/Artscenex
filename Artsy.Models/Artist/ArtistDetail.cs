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
        public int ArtistId { get; set; }       
        public string FullName { get; set; }       
        public string ArtistBio { get; set; }
        public ArtistType? ArtistType { get; set; }
        public int? Rating { get; set; }       
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
        public List<Piece> Pieces { get; set; }
        
    }
}

//get an artist by ID
