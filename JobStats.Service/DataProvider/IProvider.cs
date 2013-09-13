using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobStats.Service.DataProvider
{
    public interface IProvider<T> where T : class
    {
        IList<T> GetObjectsFromHTMLPageSource(string keywords, string salaryMin, string salaryMax);

    }
}
