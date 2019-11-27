using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;



namespace BlazorApp2
{
    //TODO: get this workin!
    // https://docs.microsoft.com/en-us/aspnet/core/blazor/dependency-injection?view=aspnetcore-3.0
    // @inherits ICountryService

    public class CountryService : ICountryService
    {
        public IEnumerable<Country> All()
        {
            return new List<Country>
        {
            new Country {Code = "DE", Name = "Germany" },
            new Country {Code = "FR", Name = "France" },
            new Country {Code = "CH", Name = "Switzerland" },
            new Country {Code = "IT", Name = "Italy" },
            new Country {Code = "DK", Name = "Danmark" } ,
            new Country {Code = "US", Name = "United States" }
        };
        }
    }

    
    public interface ICountryRepository
    {
        Task<IReadOnlyList<Country>> GetAllCountriesAsync();
    }

   
    public class CountryRepository : ICountryRepository
    {
        private static Country[] Countries { get; set; } = new[]
        {
            new Country { Code="AU",Name="Australia" }
            //    ,
            //new Employee { FirstName = "Mark", LastName = "Doe" }
        };

        public async Task<IReadOnlyList<Country>> GetAllCountriesAsync()
        {
            await Task.Delay(100);

            return CountryRepository.Countries;
        }
    }

    public interface ICountryService
    {

        IEnumerable<Country> All();
    }

    public class Country
    {
        public string Code { get; internal set; }
        public string Name { get; internal set; }
    }
}
