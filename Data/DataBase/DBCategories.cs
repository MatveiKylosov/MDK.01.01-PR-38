using MDK._01._01_PR_38.Data.Common;
using MySql.Data.MySqlClient;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

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

        public int Add(Categories categories)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery($"INSERT INTO `Shop`.`Categories` (`Name`, `Description`) VALUES ('{categories.Name}', '{categories.Description}');", mySqlConnection);
            mySqlConnection.Close();

            int IdCategories = -1;
            mySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery(
                $"SELECT `Id` FROM `Shop`.`Categories` WHERE `Name` = '{categories.Name}' AND `Description` = '{categories.Description}'",
                mySqlConnection
                );

            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdCategories = mySqlDataReaderItem.GetInt32(0);
            }

            mySqlConnection.Close();
            return IdCategories;
        }

        public int Update(Categories categories)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"UPDATE `Shop`.`Categories` SET `Name` = '{categories.Name}', `Description` = '{categories.Description}' WHERE (`Id` = '{categories.Id}');\n", mySqlConnection);
            mySqlConnection.Close();

            int IdCategories = -1;
            mySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery(
                $"SELECT `Id` FROM `Shop`.`Categories` WHERE `Name` = '{categories.Name}' AND `Description` = '{categories.Description}'",
                mySqlConnection
                );

            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdCategories = mySqlDataReaderItem.GetInt32(0);
            }

            mySqlConnection.Close();
            return IdCategories;
        }
        public void Delete(Categories categories)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"DELETE FROM `Shop`.`Categories` WHERE `Id` = '{categories.Id}';", mySqlConnection);
            mySqlConnection.Close();
        }
    }
}
