using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PracaMagisterska.Data;
using PracaMagisterska.Models;

namespace PracaMagisterska.Controllers
{
    public class HomeController : Controller
    {
        private readonly PracaMagisterskaContext _context;
        private readonly IConfiguration configuration;

        public HomeController(PracaMagisterskaContext context)
        {
            _context = context;
        }

        // GET: TS_price_PRICELIST_ACTIONS
        public async Task<IActionResult> Index()
        {

            return View(await _context.testTable.ToListAsync());
        }

        // GET: TS_price_PRICELIST_ACTIONS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tS_price_PRICELIST_ACTIONS = await _context.testTable
                .FirstOrDefaultAsync(m => m.id_order == id);
            if (tS_price_PRICELIST_ACTIONS == null)
            {
                return NotFound();
            }

            return View(tS_price_PRICELIST_ACTIONS);
        }

        // GET: TS_price_PRICELIST_ACTIONS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TS_price_PRICELIST_ACTIONS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("action_id,action_name,shown_before_acceptence,shown_on_accept_screen,shown_on_general")] tests testTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testTable);


                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(testTable);
        }

        // GET: TS_price_PRICELIST_ACTIONS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tS_price_PRICELIST_ACTIONS = await _context.testTable.FindAsync(id);
            if (tS_price_PRICELIST_ACTIONS == null)
            {
                return NotFound();
            }
            return View(tS_price_PRICELIST_ACTIONS);
        }

        // POST: TS_price_PRICELIST_ACTIONS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("action_id,action_name,shown_before_acceptence,shown_on_accept_screen,shown_on_general")] tests tS_price_PRICELIST_ACTIONS)
        {
            if (id != tS_price_PRICELIST_ACTIONS.id_order)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tS_price_PRICELIST_ACTIONS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TS_price_PRICELIST_ACTIONSExists(tS_price_PRICELIST_ACTIONS.id_order))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tS_price_PRICELIST_ACTIONS);
        }

        // GET: TS_price_PRICELIST_ACTIONS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tS_price_PRICELIST_ACTIONS = await _context.testTable
                .FirstOrDefaultAsync(m => m.id_order == id);
            if (tS_price_PRICELIST_ACTIONS == null)
            {
                return NotFound();
            }

            return View(tS_price_PRICELIST_ACTIONS);
        }

        // POST: TS_price_PRICELIST_ACTIONS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tS_price_PRICELIST_ACTIONS = await _context.testTable.FindAsync(id);
            _context.testTable.Remove(tS_price_PRICELIST_ACTIONS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TS_price_PRICELIST_ACTIONSExists(int id)
        {
            return _context.testTable.Any(e => e.id_order == id);
        }


        [HttpGet]
        public async Task<ActionResult> RunTest(string testType, int numOfTests)
        {
            object arrayOfData = null;
            //List<string> arrayOfData = new List<string>();
            List<long> arrayOfTime = new List<long>();
            //based on the type to filter data.
            if (testType == "0")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var testHelper = new testORMHelper(_context);
                    arrayOfData = await _context.testTable.ToListAsync(); //testHelper.test(this.configuration);
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
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.TestWithOrderBy();
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
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.TestWithGroupBy();
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
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.InsertTest();
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
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.InsertTest();
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
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.SelectLeftJoin();
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
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.SelectJoin();
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }
            if (testType == "6")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.SelectRandom();
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }
            if (testType == "7")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.SelectNull();
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }

            if (testType == "8")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.SelectWhereDate();
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }


            if (testType == "9")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.SelectWhereDate();
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }

            if (testType == "10")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.SelectWhereIdJoin();
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }

            if (testType == "11")
            {
                // create and start a Stopwatch instance

                for (int i = 0; i < numOfTests; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var test = new testORMHelper(_context);
                    arrayOfData = await test.remove();
                    stopwatch.Stop();
                    arrayOfTime.Add(stopwatch.ElapsedMilliseconds);
                }
            }
            string[] strArray = Array.ConvertAll(arrayOfTime.ToArray(), ele => ele.ToString());


            return Json(new { ok = true, returnURL = Url.Action("Index"), arrayOfData, time = arrayOfTime, csvFile = ArrayToCsv(strArray) });



        }
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
