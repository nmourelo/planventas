using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Helpers
{
    //TODO codigo de zuluaga para cargar cosas al azure  por ahora es para estudiar
    public class BlobHelper : IBlobHelper
    {

        //public BlobHelper(IConfiguration configuration)
        //{
        //    //para cargar el connection string desde el appsettings es un ejemplo
        //    string con = configuration.GetConnectionString("DefaultConnection");
        //}
        public Task<Guid> DeleteBlobAsync(Guid id, string ContainerName)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UploadBlobAsync(IFormFile file, string ContainerName)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UploadBlobAsync(byte[] file, string ContainerName)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UploadBlobAsync(string image, string ContainerName)
        {
            throw new NotImplementedException();
        }
    }
}
