using MediatR;
using Orion.Application.CommonAppLayer.DTOs;

namespace Orion.Application.CommonAppLayer.UseCases.FileStorageUaseCases.UploadImages
{
    public class UploadImagesCommand : IRequest<UrlsDto>
    {
        public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
    }
}