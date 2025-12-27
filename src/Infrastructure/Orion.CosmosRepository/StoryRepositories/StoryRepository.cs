using Microsoft.Azure.Cosmos;
using Orion.Application.StoryAppLayer.Gateway;
using Orion.Domain.StoryDomain.Entities;

namespace Orion.CosmosRepository.StoryRepositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly IStoryCosmosContext _cosmosContext;

        public StoryRepository(IStoryCosmosContext cosmosContext)
        {
            _cosmosContext = cosmosContext;
        }

        public async Task<Story> AddAsync(Story story)
        {
            var partitionKey = new PartitionKey(story.Id.ToString());
            var result = await _cosmosContext.StoryContainer.CreateItemAsync(story, partitionKey);
            return result.Resource;
        }

        public async Task<IEnumerable<Story>> GetAsync()
        {
            var queryDefinition = new QueryDefinition("SELECT * FROM Story");
            var query = _cosmosContext.StoryContainer.GetItemQueryIterator<Story>(queryDefinition);
            var stories = new List<Story>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                stories.AddRange(response.ToList());
            }
            return stories;
        }

        public async Task<Story> GetByIdAsync(Guid id)
        {
            var partitionKey = new PartitionKey(id.ToString());
            var result = await _cosmosContext.StoryContainer.ReadItemAsync<Story>(id.ToString(), partitionKey);
            return result.Resource;
        }

        public async Task<Story> RemoveAsync(Guid id)
        {
            var recordToDelete = await GetByIdAsync(id);
            var partitionKey = new PartitionKey(id.ToString());
            var result = await _cosmosContext.StoryContainer.DeleteItemAsync<Story>(id.ToString(), partitionKey);
            return recordToDelete;
        }

        public async Task<Story> UpdateAsync(Story story)
        {
            var partitionKey = new PartitionKey(story.Id.ToString());
            var result = await _cosmosContext.StoryContainer.UpsertItemAsync(story, partitionKey);
            return result.Resource;
        }
    }
}
