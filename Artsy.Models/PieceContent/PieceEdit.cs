using Artsy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class PieceEdit
    {
        public int PieceId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public PieceType? PieceType { get; set; }
        public int ArtistId { get; set; }
//probably need to make piece class have a non-nullable modified to 
//put in edit parse it in the other models? think about it
    }
}
