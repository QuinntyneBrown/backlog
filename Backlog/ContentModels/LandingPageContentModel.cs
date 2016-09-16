using Backlog.Configuration;
using Backlog.Services;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backlog.ContentModels
{    
    public class LandingPageContentModel: ILandingPageContentModel
    {
        [InjectionConstructor]
        public LandingPageContentModel(ICacheProvider cacheProvider, IAppConfiguration appConfiguration)
        :this(cacheProvider.GetCache(), appConfiguration) {}

        public LandingPageContentModel(ICache cache, IAppConfiguration appConfiguration)
        {
            _cache = cache;
            _appConfiguration = appConfiguration;
        }

        public ILandingPageContentModel Get()
        {
            var contentModel = new LandingPageContentModel(_cache, _appConfiguration);
            
            return contentModel;
        }

        public virtual async Task<dynamic> GetEpicThemesAsync()
        {
            var uri = $"{_appConfiguration.BaseUri}/api/theme/get/epic";
            var responseMessage =  new HttpClient().GetAsync($"{uri}").Result;
            return await responseMessage.Content.ReadAsAsync<dynamic>();
        }

        [JsonConverter(typeof(StringEnumConverter))]
		public ContentModelType ContentModelType { get; set; } = ContentModelType.LandingPage;

        protected readonly ICache _cache;
        protected readonly IAppConfiguration _appConfiguration;
    }
}
