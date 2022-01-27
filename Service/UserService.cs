using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserService
    {
        public UserDTO RegisterUser(UserDTO user)
        {
            return new UserDTO
            {
                Username = user.Username,
                Lname = user.Lname,
                Fname = user.Fname,
                email = user.email,
            };
        }
        public bool LoginUser(UserDTO user)
        {
            //Check password and username 
            return true;
        }
    }
}
