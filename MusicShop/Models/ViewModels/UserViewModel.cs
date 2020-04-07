using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.ViewModels
{
    public class UserViewModel
    {

        
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Id { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
