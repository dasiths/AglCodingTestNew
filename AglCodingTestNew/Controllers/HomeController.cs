using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AglCodingTestNew.Models;
using AglCodingTestNew.Queries.GetJson;

namespace AglCodingTestNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetAglJsonOutputQuery _getAglJsonOutputQuery;

        public HomeController(IGetAglJsonOutputQuery getAglJsonOutputQuery)
        {
            _getAglJsonOutputQuery = getAglJsonOutputQuery;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            var url = "http://agl-developer-test.azurewebsites.net/people.json";
            var jsonResult = await _getAglJsonOutputQuery.QueryAsync(url);

            ViewData["Message"] = "Display AGL JSON";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
