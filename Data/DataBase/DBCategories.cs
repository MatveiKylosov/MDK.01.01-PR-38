using MySql.Data.MySqlClient;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace MDK._01._01_PR_38.Data.DataBase
{
    public class DBCategories : ICategories
    {
        public IEnumerable<Categories> AllCategories { 
            get 
            { 
                List<Categories> categories = new List<Categories>();
                MySqlConnection mySqlConnection = Data.Common.Connection.MySqlOpen();
                MySqlDataReader CategoriesData = Data.Common.Connection.MySqlQuery("SELECT * FROM Shop.Categories ORDER BY 'Name';", mySqlConnection);

                while (CategoriesData.Read())
                {
                    categories.Add(new Categories() 
                    {
                        Id = CategoriesData.IsDBNull(0) ? -1 : CategoriesData.GetInt32(0),
                        Name = CategoriesData.IsDBNull(1) ? null : CategoriesData.GetString(1),
                        Description = CategoriesData.IsDBNull(2) ? null : CategoriesData.GetString(2),
                    });
                }

                return categories;
            } 
        }
    }
}
