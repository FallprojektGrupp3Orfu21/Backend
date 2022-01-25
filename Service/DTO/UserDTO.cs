using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class UserDTO
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } //THis way of authing should in no way shape or form be allowed to persist to release. 
        public string email { get; set; }
     }
}
