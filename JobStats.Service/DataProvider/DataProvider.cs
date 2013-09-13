using CsQuery;
using JobStats.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStats.Service.DataProvider
{
    public class DataProvider<T> : IProvider<T> where T : class
    {
        //keywords=.NET&salary_min=0&salary_max=10000
        readonly string urlBase = "http://djinni.co/search/?";
        private IConverter<T> converter;
        string currentUrl;
        string location = "*";

        Country selectedCountry = Country.Worldwide;

        public DataProvider(IConverter<T> converter)
        {
            this.converter = converter;
            currentUrl = urlBase;
        }
        public DataProvider<T> AddCountry(Country country)
        {
            selectedCountry = country;
            return this;
        }
        public DataProvider<T> AddCity(string location)
        {
            this.location = location;
            return this;
        }
        public IList<T> GetObjectsFromHTMLPageSource(string keywords, string salaryMin, string salaryMax)
        {
            string url = BuildUrl(keywords, salaryMin, salaryMax);

            var cq = CQ.CreateFromUrl(url);

            return converter.ConvertFromHTML(cq, ".span9 > div.row");

        }

        private string BuildUrl(string keywords, string salaryMin, string salaryMax)
        {
            currentUrl = string.Format("{0}region={1}&location={2}", urlBase, selectedCountry.ToString(), location);
            return string.Format("{0}&keywords={1}&salary_min={2}&salary_max={3}", currentUrl, keywords, salaryMin, salaryMax);
        }

    }
}


