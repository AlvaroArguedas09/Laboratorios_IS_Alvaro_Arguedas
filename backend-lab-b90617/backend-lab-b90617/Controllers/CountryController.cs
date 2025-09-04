using backend_lab_b90617.Models;
using backend_lab_b90617.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab_b90617.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public  List<CountryModel> Get()
        {
            var paises = _countryService.GetCountries();
            return paises;

        }
    }

}
