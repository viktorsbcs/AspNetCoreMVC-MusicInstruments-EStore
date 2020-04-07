using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.ViewModels
{
    public class UserViewModel
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Id { get; set; }

        public IList<string> Roles { get; set; }
    }
}
