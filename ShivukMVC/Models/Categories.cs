using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ShivukMVC.Models
{
    public class Categories
    {

        //List<Category> categoriesList = new List<Category>();
        string connectionString = "Server=MYSQL6002.site4now.net;Database=db_a3e2b9_shivuk;Uid=a3e2b9_shivuk;Pwd=Bar1982!@;SSL Mode=None;CharSet=UTF8";


        public List<Category> GetAllProducts()
        {
            List<Category> categoriesList = new List<Category>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand("Select ProductID,HebrewTitle, Quantity,EnglishTitle,PicturesLink,p.CategoryID ,Description,c.CategoryTitle " +
                "From Products p Left Join Categories c on p.CategoryID=c.CategoryID where p.isdeleted=0 and p.quantity>0 Order By c.CategoryTitle,p.HebrewTitle ASC", connection);
            
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                int? currentCategory = -1;


                Category cat = null;
                Products prods = null;

                while (reader.Read())
                {

                    if (currentCategory != (reader.IsDBNull(5)==true?0:reader.GetInt32(5)))
                    {
                        currentCategory = (reader.IsDBNull(5) == true ? 0 : reader.GetInt32(5));
                        cat = new Category(); 
                        cat.CategoryID = currentCategory.HasValue?currentCategory.Value:0;
                        cat.CategoryTitle =(reader.IsDBNull(7) == true ? "ללא קטגוריה" : reader.GetString(7));
                        prods = new Products();
                        cat.AddProducts(prods);
                        categoriesList.Add(cat);
                    }

               
                        prods.AddProduct(new Product
                        {
                            ProductID = reader.GetString("ProductID"),
                            HebrewTitle = reader.GetString("HebrewTitle"),
                            Quantity = reader.GetInt32("Quantity"),
                            EnglishTitle = reader.GetString("EnglishTitle"),
                            PictureLink = reader.GetString("PicturesLink"),
                            CategoryID = reader.IsDBNull(5) == false ? reader.GetInt32(5) : 0,
                            Description = reader.GetString("Description")
                        });
                }


                   
                
            
            connection.Close();

            return categoriesList;
        }

        


    }
}
