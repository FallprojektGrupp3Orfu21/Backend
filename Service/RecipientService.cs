using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTO;
using DAL.Models;

namespace Service
{
    public class RecipientService
    {

        public bool CreateRecipient(string userName, string recipientName, string recipientCity, int recipientId)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(user => user.UserName == userName).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("No user with this username.");
                }
                var newRecipient = new Recipient
                {
                    Id = recipientId,
                    Name = recipientName,
                    City = recipientCity,
                };

                if (user.RecipientNav == null)
                {
                    user.RecipientNav = new List<Recipient> { newRecipient };
                }

                user.RecipientNav.Add(newRecipient);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
       
        }
    }
}
