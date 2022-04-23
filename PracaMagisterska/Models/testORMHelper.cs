using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            List<string> abc = new List<string>();

           


            return (IActionResult) await _context.TS_price_PRICELIST_ACTIONS.ToListAsync();

        }

       

        public async Task<List<TS_price_PRICELIST_ACTIONS>> TestWithOrderBy()
        {

            var array = from s in _context.TS_price_PRICELIST_ACTIONS
                        select s;
            array =array.OrderBy(s => s.action_name);
          

            return await array.AsNoTracking().ToListAsync();

        }

        public async Task<List<String>> TestWithGroupBy()
        {
    

            var array = _context.TS_price_PRICELIST_ACTIONS
            .GroupBy(u => u.action_name)
            .Select(u => u.Key)
            .ToList();

            return array;

        }

        public async Task<List<TS_price_PRICELIST_ACTIONS>> InsertTest()
        {
            List<TS_price_PRICELIST_ACTIONS> array = await _context.TS_price_PRICELIST_ACTIONS.ToListAsync();
       

            TS_price_PRICELIST_ACTIONS newItem = new TS_price_PRICELIST_ACTIONS();
            newItem.action_name = RandomString(10);
            newItem.shown_before_acceptence = 1;
            newItem.shown_before_acceptence = 1;
            newItem.shown_on_accept_screen = 1;
            newItem.shown_on_general = 1;

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
    }
}
