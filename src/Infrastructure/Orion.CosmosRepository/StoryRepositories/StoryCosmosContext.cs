using Microsoft.Azure.Cosmos;
using Orion.CosmosRepository.Settings;

namespace Orion.CosmosRepository.StoryRepositories
{
    public class StoryCosmosContext : IStoryCosmosContext
    {
        public StoryCosmosContext(CosmosSettings cosmosSettings)
        {            
            CosmosClient client = new CosmosClient(cosmosSettings.EndPoint, cosmosSettings.Key);
            StoryContainer = client.GetContainer(cosmosSettings.DatabaseName, cosmosSettings.StoryContainer);
        }

        public Container StoryContainer { get; }
    }
}
