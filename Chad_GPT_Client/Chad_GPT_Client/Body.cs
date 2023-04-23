using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chad_GPT_Client
{
    public class Body
    {
        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
    }
}
