using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Helpers
{
    interface IBlobHelper
    {
        Task<Guid> UploadBlobAsync(IFormFile file, string ContainerName);

        Task<Guid> UploadBlobAsync(byte[] file, string ContainerName);

        Task<Guid> UploadBlobAsync(string image, string ContainerName);

        Task<Guid> DeleteBlobAsync(Guid id, string ContainerName);

    }
}
