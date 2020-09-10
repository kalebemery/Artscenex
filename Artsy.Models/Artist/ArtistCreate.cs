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
        [Display(Name = "Full Name:")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Artist Bio:")]
        public string ArtistBio { get; set; }
        [Display(Name = "Expertise in:")]
        public ArtistType? ArtistType { get; set; }

    }


}
