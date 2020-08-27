using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI_Demo.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required] //Database will not allow a save if there is nothing for a required property.
        [ForeignKey("Customer")] //Links to Customer class. But Db entity will be called "Customer Id"
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        [ForeignKey(nameof(Product))]
        public string ProductSKU { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int ItemCount { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}