using System.Net.Http.Headers;
using System.Text;

namespace API
{
    public static class UserNameAndPassword
    {
        public static List<String> GetUserNameAndPassword(AuthenticationHeaderValue header)
        {
            var credentialsAsbase64 = header.Parameter;
            byte[] data = Convert.FromBase64String(credentialsAsbase64);
            string decodedString = Encoding.UTF8.GetString(data);
            var splitString = decodedString.Split(":");
            var Username = splitString[0];
            var Password = splitString[1];
            return new List<String>
            {
                Username,
                Password
            };
        }
    }
}
