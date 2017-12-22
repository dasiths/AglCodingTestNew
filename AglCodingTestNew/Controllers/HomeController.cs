using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AglCodingTestNew.Models;
using AglCodingTestNew.Queries.GetDomainModel;
using AglCodingTestNew.Queries.GetJson;
using AglCodingTestNew.Queries.GetViewModel;
using AglCodingTestNew.Settings;

namespace AglCodingTestNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetAglJsonOutputQuery _getAglJsonOutputQuery;
        private readonly IGetDomainModelsFromDtosQuery _getDomainModelsFromDtosQuery;
        private readonly IGetViewModelFromDomainModelQuery _getViewModelFromDomainModelQuery;
        private readonly ISettings _settings;

        public HomeController(IGetAglJsonOutputQuery getAglJsonOutputQuery, 
            IGetDomainModelsFromDtosQuery getDomainModelsFromDtosQuery, 
            IGetViewModelFromDomainModelQuery getViewModelFromDomainModelQuery, 
            ISettings settings)
        {
            _getAglJsonOutputQuery = getAglJsonOutputQuery;
            _getDomainModelsFromDtosQuery = getDomainModelsFromDtosQuery;
            _getViewModelFromDomainModelQuery = getViewModelFromDomainModelQuery;
            _settings = settings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            // Call url to get json stirng
            var jsonResult = await _getAglJsonOutputQuery.QueryAsync(_settings.JsonUrl);

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
