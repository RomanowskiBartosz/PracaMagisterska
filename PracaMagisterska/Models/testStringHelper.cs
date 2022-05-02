using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PracaMagisterska.Models
{
    public class testStringHelper
    {
        private readonly IConfiguration configuration;
                  
    
        public List<string> test(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("Select * from tests", conection);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                abc.Add(reader[0].ToString() + reader[1].ToString());
                testStringHelper.ReadSingleRow((IDataRecord)reader);
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
                testStringHelper.ReadSingleRow((IDataRecord)reader);
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
            SqlCommand com = new SqlCommand("Select top(1000) * from tests order by id_order", conection);
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
                testStringHelper.ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();

            conection.Close();


            var arrayOfData = new List<string>(abc.ToArray());



            return arrayOfData;

        }

        /* public List<string> InsertTest(IConfiguration config)
         {
             var configuration = config;

             string connectionstring = configuration.GetConnectionString("defaultConnectionString");
             List<string> abc = new List<string>();
             SqlConnection conection = new SqlConnection(connectionstring);
             conection.Open();

             SqlCommand com = new SqlCommand(" INSERT INTO[dbo].[testWithForeignKey]   ([nvarcahrRow] ,[DecimalRow]  ,[IntRow]  ,[tinyint]  ,[testIdNr]) values " + "(@nvarcahrRow,@DecimalRow,@IntRow,@tinyint,@testIdNr)", conection);



             SqlParameter[] param = new SqlParameter[5];
             param[0] = new SqlParameter("@nvarcahrRow", RandomString(10));
             param[1] = new SqlParameter("@DecimalRow", RandomFloat(10));
             param[2] = new SqlParameter("@IntRow", RandomInt(10));
             param[3] = new SqlParameter("@tinyint", RandomBool(10));
             param[4] = new SqlParameter("@testIdNr", RandomInt(32000));
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

             conection.Close();


             var arrayOfData = new List<string>(abc.ToArray());



             return arrayOfData;

         }*/

        public List<string> InsertTest(IConfiguration config)
        {
            var configuration = config;

            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();
            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();

            SqlCommand com = new SqlCommand(" INSERT INTO[dbo].[testWithForeignKey2] ([nvarcharColumn] ,[Data]  ,[nvarchar10] ,[date2] ,[decimalColumn1] ,[testsWithForeignKeyid]) VALUES " + "(@nvarcahrRow, @date, @nvarchar10, @date2, @decimalColumn1, @testsWithForeignKeyid)", conection);



            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@nvarcahrRow", RandomString(5));
            param[1] = new SqlParameter("@date", RandomTime().ToString("yyyy-MM-dd HH:mm:ss.fff"));
            param[2] = new SqlParameter("@nvarchar10", RandomString(5));
            param[3] = new SqlParameter("@date2", RandomTime().ToString("yyyy-MM-dd HH:mm:ss.fff"));
            param[4] = new SqlParameter("@decimalColumn1", RandomFloat(32000));
            param[5] = new SqlParameter("@testsWithForeignKeyid", RandomInt(3200));
            com.Parameters.Add(param[0]);
            com.Parameters.Add(param[1]);
            com.Parameters.Add(param[2]);
            com.Parameters.Add(param[3]);
            com.Parameters.Add(param[4]);
            com.Parameters.Add(param[5]);

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



        public List<string> TestLeftJoin(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("select * from tests left join testWithForeignkey on tests.id_order=testWithForeignkey.testIdNr ", conection);
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


        public List<string> TestJoin(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("select * from tests join testWithForeignkey on tests.id_order=testWithForeignkey.testIdNr", conection);
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


        public List<string> TestRandomSelect(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("select * from tests where @id", conection);
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


        public List<string> TestSelectNull(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("select * from tests where order_attention is not null", conection);
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

        public List<string> TestSelectWhereDate(IConfiguration config)
        {
            var configuration = config;
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");
            List<string> abc = new List<string>();

            SqlConnection conection = new SqlConnection(connectionstring);
            conection.Open();
            SqlCommand com = new SqlCommand("select * from tests where [create_date]<@date", conection);

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
            SqlCommand com = new SqlCommand("select * from tests where  id_order>@id", conection);
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
            SqlCommand com = new SqlCommand("select * from tests join (select * from  testWithForeignkey where IntRow>@intRow) s on tests.id_order= s.testIdNr", conection);
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
            SqlCommand com = new SqlCommand(" DELETE  from [testInsert] where [id_agreement_silosy]=@id", conection);
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

        public static int RandomInt(int length)
        {
            Random random = new Random();
             return random.Next(length)+1;
        }

        public static int RandomBool(int length)
        {
            Random random = new Random();
            return (random.Next(1)%2);
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
        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}", dataRecord[0]));
        }
    }
}
