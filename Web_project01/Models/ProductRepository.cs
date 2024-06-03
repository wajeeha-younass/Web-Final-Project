//using Microsoft.Data.SqlClient;

//namespace Web_project01.Models
//{
//    public class ProductRepository
//    {
//        public List<ProductInfo> GetData()
//        {
//            List<ProductInfo> data = new List<ProductInfo>();
//            string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                SqlCommand cmd = new SqlCommand("Select * from ProductInfo", conn);
//                SqlDataReader reader = cmd.ExecuteReader();

//                while (reader.Read())
//                {
//                    ProductInfo pr = new ProductInfo();
//                    pr.ProductId = Convert.ToInt32(reader["ProductId"]);
//                    pr.Name = reader["Name"].ToString();
//                    pr.Price = Convert.ToDouble(reader["Price"]);
//                    pr.ImageUrl = reader["ImageUrl"].ToString();
//                    data.Add(pr);
//                }
//            }
//            return data;

//        }

//        public void addItemInDB(ProductInfo p)
//        {
//            Console.WriteLine("this is data" + p.Name);
//            string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
               
//                SqlCommand cmd = new SqlCommand("Insert into ProductInfo(Name,Price,ImageURL) values(@Name,@Price,@ImageURL)",conn);
//                cmd.Parameters.AddWithValue("@Name", p.Name);
//                cmd.Parameters.AddWithValue("@Price", p.Price);
//                cmd.Parameters.AddWithValue("@ImageURL", p.ImageUrl);
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void deleteInDB(int id)
//        {
//            string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
//            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
//            {
//                //Console.WriteLine("Id in model" + id);
//                sqlConnection.Open();
//                SqlCommand cmd = new SqlCommand("Delete from ProductInfo where ProductId = @ID", sqlConnection);
//                cmd.Parameters.AddWithValue("@ID", id);
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void updateInDB(ProductInfo p)
//        {
//            Console.WriteLine("PRICE " + p.Price);

//            string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
//            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
//            {
//                sqlConnection.Open();
//                SqlCommand cmd = new SqlCommand("Update ProductInfo set ", sqlConnection);
//                Console.WriteLine("PRICE " + p.Price);
//                // Check and add parameters based on the properties of p
//                if (!string.IsNullOrEmpty(p.Name))
//                {
//                    cmd.CommandText += "Name = @Name, ";
//                    cmd.Parameters.AddWithValue("@Name", p.Name);
//                }

               
//                if (p.Price != 0)
//                {
//                    cmd.CommandText += "Price = @Price, ";
//                    cmd.Parameters.AddWithValue("@Price", p.Price);
//                }

//                if (!string.IsNullOrEmpty(p.ImageUrl))
//                {
//                    cmd.CommandText += "ImageUrl = @ImageUrl, ";
//                    cmd.Parameters.AddWithValue("@ImageUrl", p.ImageUrl);
//                }

//                // Remove the trailing comma and space
//                cmd.CommandText = cmd.CommandText.TrimEnd(',', ' ');

//                // Add the condition for the WHERE clause
//                cmd.CommandText += " where ProductId = @ID";
//                cmd.Parameters.AddWithValue("@ID", p.ProductId);

//                try
//                {
//                    cmd.ExecuteNonQuery();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            }
//        }

//    }

//}