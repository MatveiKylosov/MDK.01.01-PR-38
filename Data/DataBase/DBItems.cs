using MySql.Data.MySqlClient;
using Shop.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace MDK._01._01_PR_38.Data.DataBase
{
    public class DBItems : Shop.Data.Interfaces.IItems
    {
        public IEnumerable<Categories> Categories = new DBCategories().AllCategories;

        public IEnumerable<Items> AllItems { 
            get
            {
                List<Items> items = new List<Items>();
                MySqlConnection mySqlConnection = Data.Common.Connection.MySqlOpen();
                MySqlDataReader ItemsData = Data.Common.Connection.MySqlQuery("SELECT * FROM Shop.items ORDER BY `Name`;", mySqlConnection);

                while (ItemsData.Read())
                {
                    items.Add(new Items)
                }
            } 
        }

    }
}
