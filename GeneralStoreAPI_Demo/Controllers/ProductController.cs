using GeneralStoreAPI_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralStoreAPI_Demo.Controllers
{
    public class ProductController : ApiController
    {
        private StoreDbContext _context = new StoreDbContext();

        //Post
        public IHttpActionResult Post(Product product)
        {
            if (product == null)
            {
                return BadRequest("Your request body cannot be empty.");
            }
            product.SKU = GenerateSku(product.Name); //Generates SKU for product

            // if the ModelState is not valid
            if (ModelState.IsValid == true)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //Get
        public IHttpActionResult Get()
        {
            List<Product> products = _context.Products.ToList();
            if (products.Count != 0)
            {
                return Ok(products);
            }
            return BadRequest("Your database contains no customers.");
        }

        //Get{id}

        public IHttpActionResult Get(string sku)
        {
            Product product = _context.Products.Find(sku);
                if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //Put {id}

        //Delete{id}

        private string GenerateSku(string productName)
        {
            Random random = new Random();
            var randItemNum = random.Next(0, 1000).ToString();
            var itemId = new string('0', 3 - randItemNum.Length) + randItemNum;
            return $"EFA-{productName.Substring(0, 3)}-{itemId}";
        }
        //{
        //    // Initialize a Random object so we can randomly assign this a number
        //    Random random = new Random();​
        // // Get a Random number and turn it into a string
        // var randItemNum = random.Next(0, 1000).ToString();​
        // // Construct a 3 character string based on the above number. If the number is less than 3 digits, add 0's in front of it to make it 3 digits
        // var itemId = new string('0', 3 - randItemNum.Length) + randItemNum;​
        // // Create the entire SKU and return it
        // return $"EFA-{productName.Substring(0, 3)}-{itemId}";

        //}

    }
}
