using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AglCodingTestNew.Models;
using AglCodingTestNew.Queries.GetDomainModel;
using AglCodingTestNew.Queries.GetJson;

namespace AglCodingTestNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetAglJsonOutputQuery _getAglJsonOutputQuery;
        private readonly IGetDomainModelsFromDtosQuery _getDomainModelsFromDtosQuery;

        public HomeController(IGetAglJsonOutputQuery getAglJsonOutputQuery, 
            IGetDomainModelsFromDtosQuery getDomainModelsFromDtosQuery)
        {
            _getAglJsonOutputQuery = getAglJsonOutputQuery;
            _getDomainModelsFromDtosQuery = getDomainModelsFromDtosQuery;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {

            // Get settings
            var url = "http://agl-developer-test.azurewebsites.net/people.json";

            // Call url to get json stirng
            var jsonResult = await _getAglJsonOutputQuery.QueryAsync(url);

            // Map result to view model
            var persons = await _getDomainModelsFromDtosQuery.QueryAsync(jsonResult);

            // Set data to display
            ViewData["Message"] = "Display AGL JSON";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
