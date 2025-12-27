using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.CosmosRepository.Settings
{
    public class CosmosSettings
    {
        public string EndPoint { get; set; }
        public string Key { get; set; }
        public string DatabaseName { get; set; }
        public string StoryContainer { get; set; }
    }
}
