using API.Application.Photos;
using Microsoft.AspNetCore.Http;

namespace API.Application.Interfaces
{
    public interface IPhotoAccessor
    {
         PhotoUploadResult AddPhoto(IFormFile file);

         string DeletePhoto(string publicId);
    }
}