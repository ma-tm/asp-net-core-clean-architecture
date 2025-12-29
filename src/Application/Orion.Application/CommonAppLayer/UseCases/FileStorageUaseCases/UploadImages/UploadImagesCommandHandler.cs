using MediatR;
using Orion.Application.CommonAppLayer.DTOs;
using Orion.Application.CommonAppLayer.Interfaces;

namespace Orion.Application.CommonAppLayer.UseCases.FileStorageUaseCases.UploadImages
{
    public class UploadImagesCommandHandler : IRequestHandler<UploadImagesCommand, UrlsDto>
    {
        private readonly IFileStorageService _fileStorageService;

        public UploadImagesCommandHandler(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public async Task<UrlsDto> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
        {
            var urls = await _fileStorageService.UploadAsync(request.Files);
            return urls;
        }
    }
}
