using DisplayCountryDetailsApi.Models;

namespace DisplayCountryDetailsApi.IRepository
{
    public interface ICountryRepository
    {
        Country GetCountryDetailsByPhoneNumberCode(string phoneNumber);
    }
}
