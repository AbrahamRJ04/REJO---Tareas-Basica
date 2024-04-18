using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model_Layer
{
    public class Result
    {
        public bool Correct { get; set; }
        public Object Object { get; set; }
        public List<object> Objects { get; set; }
        public string ErrorMessage { get; set; }
        public Exception exception { get; set; }

    }
}
