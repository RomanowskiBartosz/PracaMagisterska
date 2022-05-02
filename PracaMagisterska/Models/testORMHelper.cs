using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PracaMagisterska.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace PracaMagisterska.Models
{
    public class testORMHelper
    {
        private readonly IConfiguration configuration;

        private readonly PracaMagisterskaContext _context;
        public testORMHelper(PracaMagisterskaContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> testAsync()
        {
            
            string connectionstring = configuration.GetConnectionString("defaultConnectionString");

            return (IActionResult) await _context.testTable.ToListAsync();

        }

       

        public async Task<List<tests>> TestWithOrderBy()
        {

            var array = from s in _context.testTable
                        select s;
            array =array.OrderBy(s => s.CardCode);
          

            return await array.AsNoTracking().ToListAsync();

        }

        public async Task<List<String>> TestWithGroupBy()
        {
    

            var array = await _context.testTable
            .GroupBy(u => u.CardCode)
            .Select(u => u.Key)
            .ToListAsync();

            return array;

        }

        public async Task<List<tests>> SelectWhereId()
        {


            var array = await _context.testTable
            .Where(u =>u.id_order > RandomInt(32000))
             .AsNoTracking()
            .ToListAsync();

            return array;

        }
        public async Task<List<tests>> SelectWhereDate()
        {


            var array = await _context.testTable
            .Where(u => u.create_date > RandomTime())
            .AsNoTracking()
            .ToListAsync();

            return array;

        }

    
        public async Task<List<tests>> SelectRandom()
        {


            var array = await _context.testTable
            .Where(u => u.id_order == RandomInt(32000))
            
            .AsNoTracking()
            .ToListAsync();

            return array;

        }


        public async Task<IQueryable> SelectJoin()
        {
            var query = from a in _context.Set<tests>()
                        join b in _context.Set<testWithForeignKey>()
                            on a.id_order equals b.testIdNr
                        select new { a, b };


            return query;
            
        }
        public async Task<IQueryable> SelectLeftJoin()
        {


            var query = from a in _context.Set<tests>()
                        join b in _context.Set<testWithForeignKey>()
                            on a.id_order equals b.testIdNr into grouping
                        from b in grouping.DefaultIfEmpty()
                        select new { a, b };


            return query;
        }

        public async Task<IQueryable> SelectWhereIdJoin()
        {


            var query = from a in _context.Set<tests>()
                        join b in _context.Set<testWithForeignKey>()
                            on a.id_order equals b.testIdNr
                        where b.testIdNr >RandomInt(3200)
                        select new { a, b };



            return query;
        }


        
        public async Task<List<tests>> remove()
        {


            var array = await _context.testTable
            .Where(u => u.id_order == RandomInt(32000))

            .AsNoTracking()
            .ToListAsync();

            return array;


        }
        


        public async Task<List<tests>> SelectNull()
        {


            var array = await _context.testTable
            .Where(u => u.order_attention == null)
            .AsNoTracking()
            .ToListAsync();

            return array;

        }


        public async Task<List<tests>> InsertTest()
            {
                List<tests> array = await _context.testTable.ToListAsync();
       

                tests newItem = new tests();
                newItem.CardCode = RandomString(10);
                newItem.state = 1;
                newItem.payment_type_code = 1;
                newItem.user_id = 1;
                newItem.skonto_percent = 1;

                array.Add(newItem);

                return array;

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
