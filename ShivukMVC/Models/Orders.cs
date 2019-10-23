using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ShivukMVC.Models
{
    public class Orders
    {
        string connectionString = "Server=MYSQL6002.site4now.net;Database=db_a3e2b9_shivuk;Uid=a3e2b9_shivuk;Pwd=Bar1982!@;SSL Mode=None;CharSet=UTF8";
        


        public List<Order> GetAllOrders()
        {
            List<Order> ordersList = new List<Order>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand("Select o.OrderID,o.ClosingDate,p.ProductID,p.HebrewTitle,a.Quantity,p.PicturesLink " +
                                                    "From activity a "+
                                                    "Inner Join products p on a.ProductID=p.ProductID " +
                                                    "Inner Join Orders o on a.OrderID=o.OrderID " +
                                                    "Where o.OrderStatus='closed' " +
                                                    "Order by o.OrderID DESC"
                                                    , connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            int? currentOrder = -1;


            Order order = null;
            Products products = null;

            while (reader.Read())
            {

                if (currentOrder != (reader.IsDBNull(0) == true ? 0 : reader.GetInt32(0)))
                {
                    currentOrder = reader.GetInt32(0);
                    order = new Order();
                    order.OrderNumber = currentOrder.Value;
                    order.OrderClosingDate = reader.IsDBNull(1) == true ? new DateTime(9999,99,9,9,9,9) : reader.GetDateTime(1);
                    products = new Products();
                    order.AddProducts(products);
                    ordersList.Add(order);
                }

                products.AddProduct(new Product
                {
                    ProductID = reader.GetString("ProductID"),
                    HebrewTitle = reader.GetString("HebrewTitle"),
                    Quantity = reader.GetInt32("Quantity"),
                    PictureLink = reader.GetString("PicturesLink"),
                });
            }
            connection.Close();
            return ordersList;
        }
    }
}
