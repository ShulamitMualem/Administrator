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
        public void GetData(string connectionString)
        {
            string query = "select p.Name, p.Description, p.Price, p.Image_Url, c.Name as 'caregoryName'\r\nfrom Category c\r\njoin Product p\r\non c.ID=p.Category_ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
                reader.Close();
                connection.Close();
            }
        }
    }
}
