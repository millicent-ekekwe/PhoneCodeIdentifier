using DisplayCountryDetailsApi.Data;
using DisplayCountryDetailsApi.IRepository;
using DisplayCountryDetailsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DisplayCountryDetailsApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Country GetCountryDetailsByPhoneNumberCode(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 3)
            {
                
                return null; 
            }

            string countryCodeStr = phoneNumber.Substring(0, 3);

            if (!int.TryParse(countryCodeStr, out int countryCode))
            {
                // Handle parsing failure
                return null; // or throw an exception
            }

            return _context.Countries
                .Include(c => c.CountryDetails)
                .FirstOrDefault(c => c.CountryCode == countryCodeStr);
        }


    }
}
