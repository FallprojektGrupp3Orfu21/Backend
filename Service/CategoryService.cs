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
        public List<CategoryDTO> GetCategories(UserDTO user)
        {
            return new List<CategoryDTO>();
            //Returns a List of categories belonging to a certain user.
        }
        CategoryDTO AddCategory(UserCategoryDTO UC)
        {

        }
    }
}
