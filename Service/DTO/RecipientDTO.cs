using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Service.DTO
{
    public class RecipientDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }
    }
}
