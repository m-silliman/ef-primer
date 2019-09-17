using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiLEndpointCall
{
    public class ScriptResult<T> where T : new()
    {
        public bool Success { get; set; }
        public bool Cached { get; set; }
        public string Message { get; set; }
        public T Context { get; set; }
    }
}
