using backend_lab_b90617.Repositories;
using backend_lab_b90617.Models;

namespace backend_lab_b90617.Services
{
    public class CountryService
    {
        private readonly CountryRepository _countryRepository;

        public CountryService(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<CountryModel> GetCountries()
        {
            
            return _countryRepository.GetCountries();
        }
    }
}
