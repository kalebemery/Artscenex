using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string CustomerBio { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }

    }
}
