using Artsy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class ArtistEdit
    {
        public int ArtistId { get; set; }
        public string FullName { get; set; }
        public string ArtistBio { get; set; }
        public ArtistType? ArtistType { get; set; }

    }
}
