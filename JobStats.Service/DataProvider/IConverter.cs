using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobStats.Service.DataProvider
{
    public interface IConverter<T>
    {
        IList<T> ConvertFromHTML(CsQuery.CQ csQuery, string dataQuery);
    }
}
