using DisplayCountryDetailsApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisplayCountryDetailsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("{phoneNumber}")]
        public IActionResult GetCountryDetailsByPhoneNumber(string phoneNumber)
        
        {
            var country = _countryRepository.GetCountryDetailsByPhoneNumberCode(phoneNumber);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                number = phoneNumber,
                country = new
                {
                    country.CountryCode,
                    country.Name,
                    country.CountryIso,
                    countryDetails = country.CountryDetails.Select(c => new
                    {
                        c.Operator,
                        c.OperatorCode
                    })
                }
            });
        }
    }
}
