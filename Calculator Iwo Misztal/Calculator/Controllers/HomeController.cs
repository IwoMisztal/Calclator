using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Calculator.Models.Data;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string input)
        {
           

            return View();
        }

        protected readonly CalculatorDbContext _context;

        public HomeController(CalculatorDbContext ctx)
        {
            _context = ctx;
        }

        [HttpPost("/")]
        public ActionResult MakeOperation([FromForm]string input)
        {
        
         double newResult = 0;
        Operations operation = new Operations();
            if (input != null)
            {
                newResult = operation.Addition(input);
            }

            Convert.ToDecimal(newResult);
       

            _context.Operations.Add(new Operations { Result =  newResult});

            _context.SaveChanges();

            var AllResults = _context.Operations.ToList();
            

            IndexViewModel passResults = new IndexViewModel
            {
                AllResults = (AllResults),
                NewResult = newResult
            };

         

            if (_context.Operations.ToList().Capacity > 5)
            {
                var rows = from o in _context.Operations
                           select o;
                foreach (var row in rows)
                {
                    _context.Operations.Remove(row);
                }
                _context.SaveChanges();
            }

            return View("resView", passResults);
        }


    }
}


