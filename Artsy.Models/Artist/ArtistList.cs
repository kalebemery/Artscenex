using Artsy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class ArtistList
    {
        public int ArtistId { get; set; }
        public string FullName { get; set; }
        public ArtistType? ArtistType { get; set; }
        public int? Rating { get; set; }

    }
}
//get list of artists by TYPE