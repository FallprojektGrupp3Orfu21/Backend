using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class UserDTO
    {
        public string Lname { get; set; }
        public string Fname { get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public string? password { get; set; }
        public string? NewCategoryTitle { get; set; }
         
    }
}
