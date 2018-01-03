using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AglCodingTest.Core.Queries.GetHttpQuery;
using AglCodingTest.Json.Queries.GetDomainModel;
using AglCodingTest.Json.Queries.GetJson;
using Microsoft.AspNetCore.Mvc;
using AglCodingTestNew.Models;
using AglCodingTestNew.Queries.GetViewModel;
using AglCodingTestNew.Settings;
using Microsoft.Extensions.Logging;

namespace AglCodingTestNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetHttpResourceQuery _getHttpResourceQuery;
        private readonly IGetAglJsonOutputQuery _getAglJsonOutputQuery;
        private readonly IGetDomainModelsFromDtosQuery _getDomainModelsFromDtosQuery;
        private readonly IGetViewModelFromDomainModelQuery _getViewModelFromDomainModelQuery;
        private readonly ISettings _settings;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IGetAglJsonOutputQuery getAglJsonOutputQuery, 
            IGetDomainModelsFromDtosQuery getDomainModelsFromDtosQuery, 
            IGetViewModelFromDomainModelQuery getViewModelFromDomainModelQuery, 
            ISettings settings, IGetHttpResourceQuery getHttpResourceQuery, 
            ILogger<HomeController> logger)
        {
            _getAglJsonOutputQuery = getAglJsonOutputQuery;
            _getDomainModelsFromDtosQuery = getDomainModelsFromDtosQuery;
            _getViewModelFromDomainModelQuery = getViewModelFromDomainModelQuery;
            _settings = settings;
            _getHttpResourceQuery = getHttpResourceQuery;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            try
            {
                // Get http resource
                var jsonPayload = await _getHttpResourceQuery.QueryAsync(_settings.JsonUrl);

                // Map json result to dto
                var jsonResult = await _getAglJsonOutputQuery.QueryAsync(jsonPayload);

                // Map result to domian model
                var persons = await _getDomainModelsFromDtosQuery.QueryAsync(jsonResult);

                // Map result to view model
                var personViewModels = await _getViewModelFromDomainModelQuery.QueryAsync(persons);

                // Set data to display
                ViewBag.Message = "AGL Test - Display Result";
                ViewBag.Model = personViewModels;

                return View();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Error();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
