using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AglCodingTestNew.Models;
using AglCodingTestNew.Queries.GetDomainModel;
using AglCodingTestNew.Queries.GetHttpQuery;
using AglCodingTestNew.Queries.GetJson;
using AglCodingTestNew.Queries.GetViewModel;
using AglCodingTestNew.Settings;

namespace AglCodingTestNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetHttpResourceQuery _getHttpResourceQuery;
        private readonly IGetAglJsonOutputQuery _getAglJsonOutputQuery;
        private readonly IGetDomainModelsFromDtosQuery _getDomainModelsFromDtosQuery;
        private readonly IGetViewModelFromDomainModelQuery _getViewModelFromDomainModelQuery;
        private readonly ISettings _settings;

        public HomeController(IGetAglJsonOutputQuery getAglJsonOutputQuery, 
            IGetDomainModelsFromDtosQuery getDomainModelsFromDtosQuery, 
            IGetViewModelFromDomainModelQuery getViewModelFromDomainModelQuery, 
            ISettings settings, IGetHttpResourceQuery getHttpResourceQuery)
        {
            _getAglJsonOutputQuery = getAglJsonOutputQuery;
            _getDomainModelsFromDtosQuery = getDomainModelsFromDtosQuery;
            _getViewModelFromDomainModelQuery = getViewModelFromDomainModelQuery;
            _settings = settings;
            _getHttpResourceQuery = getHttpResourceQuery;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
