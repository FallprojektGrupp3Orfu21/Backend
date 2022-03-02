using DAL.Models;
using Service.DTO;

namespace Service.Models
{
    public class UserService
    {
        private ExpenseCategoryService _categoryService;
        private GetExpenseDTO _expenseDTO;
        public UserService()
        {
            _categoryService = new ExpenseCategoryService();
            _expenseDTO = new GetExpenseDTO();
        }
        private int _minimumPasswordLength = 8;
        private bool IsPasswordOk(string password)
        {
            return password.Length >= _minimumPasswordLength;
        }
        public void RegisterUser(UserDTO newUser)
        {
            if (!IsPasswordOk(newUser.password))
            {
                throw new Exception("Password is too weak");
            }
            using (var context = new EconomiqContext())
            {
                if (context.Users.Where(user => user.UserName.ToLower() == newUser.Username.ToLower()).Count() > 0)
                {
                    throw new Exception("Username allready exists");
                }
                var Email = new Email
                {
                    Mail = newUser.email
                };
                var Emails = new List<Email>();
                Emails.Add(Email);
                context.Users.Add(new User
                {
                    Fname = newUser.Fname,
                    Lname = newUser.Lname,
                    UserName = newUser.Username,
                    Password = newUser.password,
                    Emails = Emails,
                    IsLoggedIn = false,
                    CreationDate = DateTime.Now,
                    City = newUser.City,
                    Gender = newUser.Gender
                });
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            _categoryService.CreateExpenseCategory(newUser.Username, "Rent");
            _categoryService.CreateExpenseCategory(newUser.Username, "Food");
            _categoryService.CreateExpenseCategory(newUser.Username, "Transport");
            _categoryService.CreateExpenseCategory(newUser.Username, "Clothing");
            _categoryService.CreateExpenseCategory(newUser.Username, "Entertainment");
        }
        public bool LoginUser(string userName, string password)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(x => x.UserName == userName).FirstOrDefault();
                user.IsLoggedIn = true;
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    throw ex; 
                }
            }

        }


        public bool DoesPasswordMatch(string username, string password)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(user => user.UserName == username).FirstOrDefault();
                return (user.UserName == username);
            }
        }
        public bool LogoutUser(string userName, string password)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(user => user.UserName == userName).FirstOrDefault();
                user.IsLoggedIn = false;
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return true;
        }
        public bool IsUserLoggedIn(string userName, string password)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(user => user.UserName == userName).FirstOrDefault();
                return (user.UserName == userName);
            }
        }
        public bool DoesUserExist(string userName)
        {
            using (var context = new EconomiqContext())
            {
                return (context.Users.Where(user => user.UserName == userName) != null);
            }
        }
    }
}
