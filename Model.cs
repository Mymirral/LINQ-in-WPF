using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_in_WPF
{
    class Model
    {
        public Model()
        {
            WordCollection = new List<string>();
            HotWordsList = new string[3];
        }
        public List<string> WordCollection { get; set; }
        public string[] HotWordsList { get; set; }
    }
}
