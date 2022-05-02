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
                  
    

        public List<string> TestProcedure(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec Select_from_tests", conection);
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

        public List<string> TestLeftJoinProcedure(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec [Select_left_join]", conection);
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


        public List<string> TestJoinProcedure(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec Select_join", conection);
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


        public List<string> TestRandomSelectProcedure(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec [Select_random_join] @id", conection);
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id", RandomInt(5));
            com.Parameters.Add(param[0]);

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


        public List<string> TestSelectNullProcedure(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec selectNull id=@id", conection);
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id", RandomInt(5));
            com.Parameters.Add(param[0]);

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

        public List<string> TestSelectWhereDateProcedure(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec selectDate @date", conection);

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@date", RandomTime());
            com.Parameters.Add(param[0]);


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

        public List<string> TestSelectWhereId(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec selectId @id", conection);

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id", RandomInt(32000));
            com.Parameters.Add(param[0]);

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


        public List<string> TestSelectJoinWhereId(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec selectJoinSelect @intRow", conection);

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@intRow", RandomInt(32000));
            com.Parameters.Add(param[0]);

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


        public List<string> TestRemove(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("exec remove @id", conection);


            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id", RandomInt(32000));
            com.Parameters.Add(param[0]);

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

        public static int RandomInt(int length)
        {
            Random random = new Random();
            return random.Next(length) + 1;
        }

        public static int RandomBool(int length)
        {
            Random random = new Random();
            return (random.Next(1) % 2);
        }

        public static float RandomFloat(int length)
        {
            Random rand = new Random();
            float randomFloat = (float)rand.NextDouble();
            return (randomFloat);
        }

        public static DateTime RandomTime()
        {
            Random rnd = new Random();
            DateTime datetoday = DateTime.Now;

            int rndYear = rnd.Next(1995, datetoday.Year);
            int rndMonth = rnd.Next(1, 12);
            int rndDay = rnd.Next(1, 30);

            DateTime generateDate = new DateTime(rndYear, rndMonth, rndDay);

            return generateDate;
        }
    }
}
