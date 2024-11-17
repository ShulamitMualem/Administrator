using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;

namespace Administrator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectDB = "data source=srv2\\pupils;initial catalog=Web_Api_328264650;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            Products product = new Products();
            int rowsEffected = product.AddNewProduct(connectDB);
            Console.WriteLine($"{rowsEffected} rows are affected");
            product.GetData(connectDB);
            Console.ReadLine();
        }
    }
}
