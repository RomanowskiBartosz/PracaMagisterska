using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracaMagisterska.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Microsoft.Extensions.Configuration;

using System.Data;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace PracaMagisterska.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            this.configuration = config;
        }
        [BindProperty]
        public int testNumber { get; set; }
        public void OnPost()
        {
            Console.WriteLine(testNumber);
            // posted value is assigned to the Number property automatically
        }
        public IActionResult Index()
        {
            return View();
        }
        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}", dataRecord[0]));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult RunTest(string testType, int numOfTests)
        {

            List<string> arrayOfData = new List<string>();
            List<long> arrayOfTime = new List<long>();
            //based on the type to filter data.
            if (testType == "0")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testHelper();
                    arrayOfData = test.test(this.configuration);
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }

            }

            if (testType == "1")
            {
                // create and start a Stopwatch instance
              
                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testHelper();
                    arrayOfData = test.TestWithOrderBy(this.configuration);
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }


            if (testType == "2")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testHelper();
                    arrayOfData = test.TestWithGroupBy(this.configuration);
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }

            if (testType == "3")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testHelper();
                    arrayOfData = test.InsertTest(this.configuration);
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }

            if (testType == "4")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testHelper();
                    arrayOfData = test.TestProcedure(this.configuration);
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }


            if (testType == "5")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testHelper();
                    arrayOfData = test.TestWithOrderByProcedure(this.configuration);
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }


            string[] strArray = Array.ConvertAll(arrayOfTime.ToArray(), ele => ele.ToString());

            return Json(new { ok = true, returnURL = Url.Action("Index"), arrayOfData, time = arrayOfTime, csvFile= ArrayToCsv(strArray) });





        }

        // Convert array data into CSV format.
        private string ArrayToCsv(string[] values)
        {
            // Get the bounds.
            int num_rows = values.GetUpperBound(0) + 1;
          

            // Convert the array into a CSV string.
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < num_rows; row++)
            {
                // Add the first field in this row.
                sb.Append(values[row]);


                sb.AppendLine();


            }

            // Return the CSV format string.
         
            return sb.ToString();
        }
    
    }

}
