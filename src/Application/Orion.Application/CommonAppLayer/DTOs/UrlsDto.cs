namespace Orion.Application.CommonAppLayer.DTOs
{
    public class UrlsDto
    {
        public ICollection<string> Urls { get; set; }

        public UrlsDto(ICollection<string> urls)
        {
            Urls = urls;
        }
    }
}
