using Artsy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class PieceList
    {
        public int PieceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public PieceType? PieceType { get; set; }
        public int ArtistId { get; set; }


    }
}
