using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Administrator
{
    internal class Products
    {
        public int AddNewProduct(string connectionString)
        {
            int rowsEffected = 0;
            string Category_ID, Name, Description, Price, Image_Url, toContinue="";
            while (toContinue != "n")
            {
                Console.WriteLine("insert Category_ID: ");
                Category_ID = Console.ReadLine();
                Console.WriteLine("insert Name: ");
                Name = Console.ReadLine();
                Console.WriteLine("insert Description: ");
                Description = Console.ReadLine();
                Console.WriteLine("insert Price: ");
                Price = Console.ReadLine();
                Console.WriteLine("insert Image_Url: ");
                Image_Url = Console.ReadLine();

                string query = "INSERT INTO Product(Category_ID, Name, Description, Price, Image_Url)" +
                    "VALUES (@Category_ID, @Name, @Description, @Price, @Image_Url)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                    using(SqlCommand cmd=new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Category_ID", SqlDbType.Int).Value= int.Parse(Category_ID);
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                    cmd.Parameters.Add("@Price", SqlDbType.NVarChar).Value = Price;
                    cmd.Parameters.Add("@Image_Url", SqlDbType.NVarChar).Value = Image_Url;
                    connection.Open();
                    rowsEffected += cmd.ExecuteNonQuery();
                    connection.Close();
                }
                Console.WriteLine("Are you want to continue? (y/n)");
                toContinue = Console.ReadLine();
            }
            return rowsEffected;
        }
    }
}
