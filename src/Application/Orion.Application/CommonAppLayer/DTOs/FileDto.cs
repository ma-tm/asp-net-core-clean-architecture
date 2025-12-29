using Orion.Application.SeedWork.Extensions;

namespace Orion.Application.CommonAppLayer.DTOs
{
    public class FileDto
    {
        public Stream Content { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }

        public string GetPathWithFileName()
        {
            string uniqueAutoGenerateFileName = Path.GetRandomFileName();
            string shortClientSideFileNameWithoutExt = Path.GetFileNameWithoutExtension(Name).TruncateLongString(10);
            string fileExtension = Path.GetExtension(Name);
            string basePath = "user1/stories/";

            return $"{basePath}{shortClientSideFileNameWithoutExt}_{uniqueAutoGenerateFileName}{fileExtension}";
        }
    }
}
