using Artsy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class ArtistCreate
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ArtistBio { get; set; }
        
        public ArtistType? ArtistType { get; set; }

    }


}
