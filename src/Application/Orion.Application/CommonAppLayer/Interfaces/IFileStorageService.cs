using Orion.Application.CommonAppLayer.DTOs;

namespace Orion.Application.CommonAppLayer.Interfaces
{
    public interface IFileStorageService
    {
        Task<UrlsDto> UploadAsync(ICollection<FileDto> files);
    }
}
