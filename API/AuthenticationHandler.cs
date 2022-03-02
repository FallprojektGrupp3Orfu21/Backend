using Service.Models;
namespace API
{
    public static class AuthenticationHandler
    {
        public static void CheckUser(HttpRequest header, UserService us)
        {
            var credentials = UserNameAndPassword.GetUserNameAndPassword(header);
            string userName = credentials[0];
            string password = credentials[1];
            if (!us.DoesUserExist(userName))
            {
                throw new Exception("Invalid username");
            }
            else if (!us.DoesPasswordMatch(userName, password))
            {
                throw new Exception("Invalid password");
            }
            else if (!us.IsUserLoggedIn(userName, password))
            {
                throw new Exception("User not logged in");
            }
        }
    }
}