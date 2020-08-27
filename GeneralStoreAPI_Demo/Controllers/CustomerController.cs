using GeneralStoreAPI_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPI_Demo.Controllers
{
    public class CustomerController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        //Post
        public IHttpActionResult Post(Customer customer)
        {
            //If an empty customer is passed in
            if (customer == null)
            {
                return BadRequest("Your request body cannot be empty.");
            }

            // if the ModelState is not valid
            if (ModelState.IsValid == true)
            {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok();
            }
            return BadRequest(ModelState);
        }
        //Get
        public IHttpActionResult Get()
        {
            List<Customer> customers = _context.Customers.ToList();
            if (customers.Count != 0)
            {
                return Ok(customers);
            }
            return BadRequest("Your database contains no customers.");
        }

        //Get{id}
        public IHttpActionResult Get(int id)
        {
            Customer customer = _context.Customers.Find(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        //Put {id}

        //Delete{id}
    }
}
