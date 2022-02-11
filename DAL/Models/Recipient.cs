namespace DAL.Models
{
    public class Recipient
    {

        public int? Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }



        //Nav properties

        public int UserNavId { get; set; }
        public User? UserNav { get; set; }




    }
}