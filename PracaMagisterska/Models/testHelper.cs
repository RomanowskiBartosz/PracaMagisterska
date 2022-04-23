using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PracaMagisterska.Models
{
    public class testHelper
    {
        private readonly IConfiguration configuration;
                  
    
        public List<string> test(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("Select * from DEA_ORDERS", conection);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                abc.Add(reader[0].ToString() + reader[1].ToString());
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();

            conection.Close();


            var arrayOfData =new List<string>(abc.ToArray());



            return arrayOfData;

        }

        public List<string> TestProcedure(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec Select_from_orders", conection);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                abc.Add(reader[0].ToString() + reader[1].ToString());
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();

            conection.Close();


            var arrayOfData = new List<string>(abc.ToArray());



            return arrayOfData;

        }



        public List<string> TestWithOrderBy(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("Select * from DEA_ORDERS order by id_order", conection);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                abc.Add(reader[0].ToString() + reader[1].ToString());
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();

            conection.Close();


            var arrayOfData = new List<string>(abc.ToArray());



            return arrayOfData;

        }


        public List<string> TestWithOrderByProcedure(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec Select_from_orders_orderBy", conection);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                abc.Add(reader[0].ToString() + reader[1].ToString());
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();

            conection.Close();


            var arrayOfData = new List<string>(abc.ToArray());



            return arrayOfData;

        }




        public List<string> TestWithGroupBy(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("Select CardCode,create_date from DEA_ORDERS group by CardCode,create_date", conection);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                abc.Add(reader[0].ToString() + reader[1].ToString());
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();

            conection.Close();


            var arrayOfData = new List<string>(abc.ToArray());



            return arrayOfData;

        }

        public List<string> InsertTest(IConfiguration config)
        {
            var configuration = config;

            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();
            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();

            SqlCommand com = new SqlCommand("insert into DEA_ORDERS(sent_to_sap_id_package,ordr_docentry,CardCode,customer_order_number,pdf_filename) values " +
                "(@sent_to_sap_id_package,@ordr_docentry,@CardCode,@customer_order_number,@pdf_filename)", conection);

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@sent_to_sap_id_package", RandomString(10));
            param[1] = new SqlParameter("@ordr_docentry", RandomString(10));
            param[2] = new SqlParameter("@CardCode", RandomString(10));
            param[3] = new SqlParameter("@customer_order_number", RandomString(10));
            param[4] = new SqlParameter("@pdf_filename", RandomString(10));
            com.Parameters.Add(param[0]);
            com.Parameters.Add(param[1]);
            com.Parameters.Add(param[2]);
            com.Parameters.Add(param[3]);
            com.Parameters.Add(param[4]);

         
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                abc.Add(reader[0].ToString() + reader[1].ToString());
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();

        


            var arrayOfData = new List<string>(abc.ToArray());



            return arrayOfData;

        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}", dataRecord[0]));
        }
    }
}
