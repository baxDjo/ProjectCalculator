using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCalculator.Interfaces
{
    public interface IParserData
    {
        public List<string> ParseData(string input);
    }
}
