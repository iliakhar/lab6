using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    public class Case
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public Case(string header, string text)
        {
            Header = header;
            Text = text;
        }
    }
}
