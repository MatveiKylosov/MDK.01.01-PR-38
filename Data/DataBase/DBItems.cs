using MDK._01._01_PR_38.Data.Common;
using MySql.Data.MySqlClient;
using Shop.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MDK._01._01_PR_38.Data.DataBase
{
    public class DBItems : Shop.Data.Interfaces.IItems
    {
        public IEnumerable<Categories> Categories = new DBCategories().AllCategories;

        public IEnumerable<Items> FindItems(string search)
        {
            List<Items> items = new List<Items>();
            MySqlConnection mySqlConnection = Data.Common.Connection.MySqlOpen();
            MySqlDataReader ItemsData = Data.Common.Connection.MySqlQuery($"SELECT * FROM Shop.items WHERE `Name` LIKE '%{search}%' ORDER BY `Name`;", mySqlConnection);

            while (ItemsData.Read())
            {
                items.Add(new Items()
                {
                    Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                    Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                    Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                    Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                    Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                    Category = ItemsData.IsDBNull(5) ? null : Categories.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                });
            }

            return items;
        }

        public IEnumerable<Items> AllItems
        {
            get
            {
                return FindItems("");
            }
        }
    
        public int Add(Items item)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"INSERT INTO `items` (`Name`, `Description`, `Img`, `Price`, `IdCategories`) VALUES ('{item.Name}', '{item.Description}', '{item.Img}', '{item.Price}', '{item.Category.Id}')", mySqlConnection);
            mySqlConnection.Close();

            int IdItem = -1;
            mySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery(
                $"SELECT `Id` FROM `items` WHERE `Name` = '{item.Name}' AND `Description` = '{item.Description}' AND `Price` = '{item.Price}' AND `IdCategories` = '{item.Category.Id}'", 
                mySqlConnection
                );

            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdItem = mySqlDataReaderItem.GetInt32(0);
            }

            mySqlConnection.Close();
            return IdItem;
        }
    }
}
