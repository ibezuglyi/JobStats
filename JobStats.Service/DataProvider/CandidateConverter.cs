using CsQuery;
using JobStats.Service.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobStats.Service.DataProvider
{
    public class CandidateConverter : IConverter<Candidate>
    {
        readonly CultureInfo DefaultCulture = CultureInfo.GetCultureInfo("Ru-ru");

        public IList<Candidate> ConvertFromHTML(CsQuery.CQ csQuery, string dataQuery)
        {
            var queryItems = csQuery[dataQuery];
            return queryItems.Select(r => CreateCandidate(r as IDomElement)).ToList();
        }

        private Candidate CreateCandidate(IDomElement domElement)
        {
            var cq = new CQ(domElement.ChildElements);
            double salary = 0;
            var link = cq.Find("a.profile").FirstOrDefault();
            var date = cq.Find("small").Text().Trim();
            var city = cq.Find("p.info").Eq(0).Text().Trim();
            var preferences = cq.Find("p.info").Eq(1).Text().Trim();
            var experience = cq.Find("p").Last().Text().Trim();
            var position = link.InnerText.Trim().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
            var splitedtitle = link.InnerText.Trim().Split(new[] { "$" }, StringSplitOptions.RemoveEmptyEntries);
            if (splitedtitle.Count() > 1) double.TryParse(splitedtitle[1], out salary);
            var url = link["href"];
            var dateadded = DateTime.Parse(date, DefaultCulture);
            position = HttpUtility.HtmlDecode(position);
            return new Candidate() { Position = position, Salary = salary, Url = url, City = city, Preferences = preferences, Experience = experience, DateAdded = dateadded };
        }
    }
}
