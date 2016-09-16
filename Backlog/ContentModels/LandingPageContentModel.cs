using Backlog.Services;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backlog.ContentModels
{    
    public class LandingPageContentModel: ILandingPageContentModel
    {
        [InjectionConstructor]
        public LandingPageContentModel(ICacheProvider cacheProvider)
        :this(cacheProvider.GetCache()){}

        public LandingPageContentModel(ICache cache)
        {
            _cache = cache;
        }

        public ILandingPageContentModel Get()
        {
            var contentModel = new LandingPageContentModel(_cache);
            
            return contentModel;
        }
		
		[JsonConverter(typeof(StringEnumConverter))]
		public ContentModelType ContentModelType { get; set; } = ContentModelType.LandingPage;

        protected readonly ICache _cache;
    }
}
