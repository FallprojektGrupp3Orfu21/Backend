using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Service.DTO;

namespace Service
{
    public class RecipientService
    {

        public bool CreateRecipient(string userName, string recipientName, string recipientCity)
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
            public List<RecipientDTO> GetRecipients(string username, string password, string? searchString = null)
            {
                using(var context = new EconomiqContext())
                {

                int userId = context.Users.Where(user => user.UserName == username).FirstOrDefault().Id;
                var recipients = context.Recipients.Where(rec => rec.UserNavId == userId);
                if(searchString != null)
                {
                    recipients = recipients.Where(recipient => recipient.Name.ToLower().StartsWith(searchString.ToLower()));
                }
                var theRecipients = new List<RecipientDTO>();
                foreach(var recipient in recipients)
                {
                    theRecipients.Add(new RecipientDTO
                    {
                        Name = recipient.Name,
                        City = recipient.City
                    });          
                }
                return theRecipients;
                }
            }

    }
}
