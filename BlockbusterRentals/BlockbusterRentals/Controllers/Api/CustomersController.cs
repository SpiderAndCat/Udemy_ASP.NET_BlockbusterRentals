using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlockbusterRentals.Models;

namespace BlockbusterRentals.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        // getting an object
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            // add new customer to _context
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            // get customer in DB to update
            var customerInDb = _context.Customers.SingleOrDefault(C => C.Id == id);

            // check for existance and validity of id
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // update customer
            customerInDb.Name = customer.Name;
            customerInDb.Birthday = customer.Birthday;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeID = customer.MembershipTypeID;

            _context.SaveChanges();

        }


        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            // check if customer exists
            var customerInDb = _context.Customers.SingleOrDefault(C => C.Id == id);

            // check for existance and validity of id
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();



            _context.SaveChanges();

        }

    }
}
