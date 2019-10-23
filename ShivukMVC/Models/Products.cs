using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ShivukMVC.Models
{
    public class Products
    {

        List<Product> products = new List<Product>();

        public void AddProduct(Product prod)
        {
            products.Add(prod);
        }
        public List<Product> _Products
        {
            get
            {
                return products;
            }
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            products = new List<Product>();
            string connectionString = "Server=MYSQL6002.site4now.net;Database=db_a3e2b9_shivuk;Uid=a3e2b9_shivuk;Pwd=Bar1982!@;SSL Mode=None;CharSet=UTF8";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand("Select ProductID,HebrewTitle, Quantity,EnglishTitle,PicturesLink,p.CategoryID ,Description,c.CategoryTitle " +
                $"From Products p Left Join Categories c on p.CategoryID=c.CategoryID Where c.CategoryId={categoryID} and p.isdeleted=0 and p.quantity>0 Order By c.CategoryTitle,p.HebrewTitle ASC", connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 bool b = reader.IsDBNull(5);
                int ссс = reader.IsDBNull(5) == false ? reader.GetInt32(5) : 0;

                products.Add(new Product
                {
                    ProductID = reader.GetString("ProductID"),
                    HebrewTitle = reader.GetString("HebrewTitle"),
                    Quantity = reader.GetInt32("Quantity"),
                    EnglishTitle = reader.GetString("EnglishTitle"),
                    PictureLink = reader.GetString("PicturesLink"),
                    CategoryID = reader.IsDBNull(5) == false ? reader.GetInt32(5) : 0,
                    CategoryTitle = reader.GetString("CategoryTitle"),
                    Description = reader.GetString("Description")
                });
            }
            connection.Close();
            return products;
        }
    }
}
