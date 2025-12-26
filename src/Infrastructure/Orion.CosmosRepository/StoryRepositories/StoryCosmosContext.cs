using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.CosmosRepository.StoryRepositories
{
    public class StoryCosmosContext : IStoryCosmosContext
    {
        public StoryCosmosContext()
        {            
            string endPoint = "https://localhost:443/";
            string key = "dgdfgd==";
            string databaseName = "OrionDb";

            CosmosClient client = new CosmosClient(endPoint, key);
            StoryContainer = client.GetContainer(databaseName, "Story");
        }

        public Container StoryContainer { get; }
    }
}
