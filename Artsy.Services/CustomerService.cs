using Artsy.Data;
using Artsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artsy.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    Id = _userId,
                    FullName = model.FullName,
                    CustomerBio = model.CustomerBio,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerDetail> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Select(
                            e =>
                                new CustomerDetail
                                {
                                    CustomerId = e.CustomerId,
                                    FullName = e.FullName,
                                    CustomerBio = e.CustomerBio,
                                    CreatedUTC = e.CreatedUTC,
                                    ModifiedUTC = e.ModifiedUTC
                                   
                                }
                        );

                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == id && e.Id == _userId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        FullName = entity.FullName,
                        CustomerBio = entity.CustomerBio,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId && e.Id == _userId);

                entity.FullName = model.FullName;
                entity.CustomerBio = model.CustomerBio;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;




            }

        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.Id == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
