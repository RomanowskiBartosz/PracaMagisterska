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
    public class TS_price_PRICELIST_ACTIONSController : Controller
    {
        private readonly PracaMagisterskaContext _context;
        private readonly IConfiguration configuration;

        public TS_price_PRICELIST_ACTIONSController(PracaMagisterskaContext context)
        {
            _context = context;
        }

        // GET: TS_price_PRICELIST_ACTIONS
        public async Task<IActionResult> Index()
        {
            return View(await _context.TS_price_PRICELIST_ACTIONS.ToListAsync());
        }

        // GET: TS_price_PRICELIST_ACTIONS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tS_price_PRICELIST_ACTIONS = await _context.TS_price_PRICELIST_ACTIONS
                .FirstOrDefaultAsync(m => m.action_id == id);
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
        public async Task<IActionResult> Create([Bind("action_id,action_name,shown_before_acceptence,shown_on_accept_screen,shown_on_general")] TS_price_PRICELIST_ACTIONS tS_price_PRICELIST_ACTIONS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tS_price_PRICELIST_ACTIONS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tS_price_PRICELIST_ACTIONS);
        }

        // GET: TS_price_PRICELIST_ACTIONS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tS_price_PRICELIST_ACTIONS = await _context.TS_price_PRICELIST_ACTIONS.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("action_id,action_name,shown_before_acceptence,shown_on_accept_screen,shown_on_general")] TS_price_PRICELIST_ACTIONS tS_price_PRICELIST_ACTIONS)
        {
            if (id != tS_price_PRICELIST_ACTIONS.action_id)
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
                    if (!TS_price_PRICELIST_ACTIONSExists(tS_price_PRICELIST_ACTIONS.action_id))
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

            var tS_price_PRICELIST_ACTIONS = await _context.TS_price_PRICELIST_ACTIONS
                .FirstOrDefaultAsync(m => m.action_id == id);
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
            var tS_price_PRICELIST_ACTIONS = await _context.TS_price_PRICELIST_ACTIONS.FindAsync(id);
            _context.TS_price_PRICELIST_ACTIONS.Remove(tS_price_PRICELIST_ACTIONS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TS_price_PRICELIST_ACTIONSExists(int id)
        {
            return _context.TS_price_PRICELIST_ACTIONS.Any(e => e.action_id == id);
        }



        public async Task<ActionResult> RunTestAsync(string testType, int numOfTests)
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
                    arrayOfData = await _context.TS_price_PRICELIST_ACTIONS.ToListAsync(); //testHelper.test(this.configuration);
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
                    arrayOfData  = await test.TestWithGroupBy();
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
                    arrayOfData  = await test.InsertTest();
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
