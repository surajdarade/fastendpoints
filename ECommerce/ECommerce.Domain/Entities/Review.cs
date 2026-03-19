using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities {
    public class Review {
        public Guid Id { get; set; }

        public Guid ProductId  { get; set; }

        public Product Product { get; set; }    

        public Guid UserId { get; set; }    

        public string Comment { get; set; } 

        public int Rating { get; set; } 
    }
}
