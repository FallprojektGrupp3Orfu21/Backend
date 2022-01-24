using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Email
    {
        int Id { get; set; }
        [System.ComponentModel.DataAnnotations.EmailAddress] 
        public String Mail { get; set; }

    }
}
