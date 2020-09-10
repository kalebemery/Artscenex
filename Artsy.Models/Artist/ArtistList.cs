using Artsy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class ArtistList
    {
        [Display(Name = "Artist Id")]
        public int ArtistId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Artist Type")]
        public ArtistType? ArtistType { get; set; }
        public int? Rating { get; set; }

    }
}
//get list of artists by TYPE