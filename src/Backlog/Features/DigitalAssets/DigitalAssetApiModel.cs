using System;
using Backlog.Model;

namespace Backlog.Features.DigitalAssets
{
    public class DigitalAssetApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Folder { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? FileModified { get; set; }
        public string Size { get; set; }
        public string ContentType { get; set; }
        public bool? IsSecure { get; set; }
        public string RelativeUrl { get { return $"api/digitalassets/serve?uniqueid={UniqueId}"; } }
        public string Url { get { return $"http://kirkbrown.azurewebsites.net/{RelativeUrl}";  } }
        public byte[] Bytes { get; set; } = new byte[0];
        public Guid? UniqueId { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public static TModel FromDigitalAsset<TModel>(DigitalAsset digitalAsset) where
            TModel : DigitalAssetApiModel, new()
        {
            var model = new TModel();
            model.Id = digitalAsset.Id;
            model.Bytes = digitalAsset.Bytes;
            model.Folder = digitalAsset.Folder;
            model.Name = digitalAsset.Name;            
            model.FileName = digitalAsset.FileName;
            model.Description = digitalAsset.Description;
            model.Created = digitalAsset.Created;
            model.FileModified = digitalAsset.FileModified;
            model.Size = digitalAsset.Size;
            model.ContentType = digitalAsset.ContentType;
            model.IsSecure = digitalAsset.IsSecure;
            model.UniqueId = digitalAsset.UniqueId;
            model.CreatedOn = digitalAsset.CreatedOn;
            model.CreatedBy = digitalAsset.CreatedBy;
            model.UploadedOn = string.Format("{0:yyyy-MM-dd HH:mm}", digitalAsset.UploadedOn);
            model.UploadedBy = digitalAsset.UploadedBy;
            return model;
        }

        public static DigitalAssetApiModel FromDigitalAsset(DigitalAsset digitalAsset)
            => FromDigitalAsset<DigitalAssetApiModel>(digitalAsset);
    }
}