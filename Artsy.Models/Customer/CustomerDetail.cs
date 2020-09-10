using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Models
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string CustomerBio { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
