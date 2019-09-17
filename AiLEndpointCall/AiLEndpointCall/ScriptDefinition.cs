using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiLEndpointCall
{
    public class ScriptDefinition
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Version { get; set; }
        public string Description { get; set; }
        public string Script { get; set; }
    }

}
