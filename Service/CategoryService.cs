using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTO; 
namespace Service
{
    public class CategoryService
    {
        public List<ExpenseCategoryDTO> GetCategories(UserDTO user)
        {
            return new List<ExpenseCategoryDTO>();
            //Returns a List of categories belonging to a certain user.
        }
        ExpenseCategoryDTO AddCategory(ExpenseCategoryDTO UC)
        {
            return new ExpenseCategoryDTO();
        }
    }
}
