using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        
        public string ProductName { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public int AmountInStock { get; set; }

        public bool InStock { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }



    }
}
