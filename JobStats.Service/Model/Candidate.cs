using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStats.Service.Model
{
    public class Candidate
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public DateTime DateAdded { get; set; }
        public string City { get; set; }
        public string Preferences { get; set; }
        public string Experience { get; set; }
        public string Url { get; set; }
    }
}
