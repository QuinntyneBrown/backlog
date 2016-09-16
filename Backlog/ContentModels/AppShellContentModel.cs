using Backlog.Services;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backlog.ContentModels
{    
    public class AppShellContentModel: IAppShellContentModel
    {
        [InjectionConstructor]
        public AppShellContentModel(ICacheProvider cacheProvider)
        :this(cacheProvider.GetCache()){}

        public AppShellContentModel(ICache cache)
        {
            _cache = cache;
        }

        public IAppShellContentModel Get()
        {
            var contentModel = new AppShellContentModel(_cache);
            
            return contentModel;
        }
		
		[JsonConverter(typeof(StringEnumConverter))]
		public ContentModelType ContentModelType { get; set; } = ContentModelType.AppShell;

        protected readonly ICache _cache;
    }
}
