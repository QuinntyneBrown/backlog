using MediatR;
using Backlog.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Backlog.Features.DigitalAssets.UploadHandlers;
using System.Collections.Specialized;
using System.Net.Http;
using System.IO;
using Backlog.Model;
using Backlog.Features.Core;
using System;
using ByteSizeLib;
using System.Data.Entity;

namespace Backlog.Features.DigitalAssets
{
    public class UploadDigitalAssetCommand
    {
        public class Request : BaseAuthenticatedRequest, IRequest<UploadDigitalAssetResponse>
        {
            public InMemoryMultipartFormDataStreamProvider Provider { get; set; }
            public bool? IsSecure { get; set; } = true;
        }

        public class UploadDigitalAssetResponse
        {
            public ICollection<DigitalAssetApiModel> DigitalAssets { get; set; }
        }

        public class UploadDigitalAssetHandler : IAsyncRequestHandler<Request, UploadDigitalAssetResponse>
        {
            public UploadDigitalAssetHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<UploadDigitalAssetResponse> Handle(Request request)
            {
                var tenant = _context.Tenants.Where(x => x.UniqueId == request.TenantUniqueId).Single();
                var user = _context.Users
                    .Include(x => x.Tenant)
                    .Where(x => x.Username == request.Username)
                    .Single();

                NameValueCollection formData = request.Provider.FormData;
                IList<HttpContent> files = request.Provider.Files;
                List<DigitalAsset> digitalAssets = new List<DigitalAsset>();
                foreach (var file in files)
                {
                    var filename = new FileInfo(file.Headers.ContentDisposition.FileName.Trim(new char[] { '"' })
                        .Replace("&", "and")).Name;
                    Stream stream = await file.ReadAsStreamAsync();
                    var bytes = StreamHelper.ReadToEnd(stream);
                    var digitalAsset = new DigitalAsset();
                    digitalAsset.FileName = filename;
                    digitalAsset.Bytes = bytes;
                    digitalAsset.IsSecure = request.IsSecure;
                    digitalAsset.Tenant = tenant;
                    digitalAsset.ContentType = $"{file.Headers.ContentType}";
                    digitalAsset.UploadedOn = DateTime.UtcNow;
                    digitalAsset.UploadedBy = user.Name;
                    digitalAsset.Size = $"{Math.Round(ByteSize.FromBytes(Convert.ToDouble(digitalAsset.Bytes.Length)).KiloBytes, 1)} KB";
                    _context.DigitalAssets.Add(digitalAsset);
                    digitalAssets.Add(digitalAsset);
                }
                
                await _context.SaveChangesAsync(request.Username);

                _cache.Remove(DigitalAssetsCacheKeyFactory.Get(request.TenantUniqueId));

                return new UploadDigitalAssetResponse()
                {
                    DigitalAssets = digitalAssets.Select(x => DigitalAssetApiModel.FromDigitalAsset(x)).ToList()
                };
            }


            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }
    }
}