using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.ViewModels
{
    public class AddProductViewModel
    {

        [Required]
        public string ProductName { get; set; }
        
        [Required]
        public string ShortDescription { get; set; }
        
        [Required]
        public string LongDescription { get; set; }
        
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageThumbnailUrl { get; set; }
        
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public int AmountInStock { get; set; }

        //public bool InStock { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        
        public int CategoryId { get; set; }
    }
}
