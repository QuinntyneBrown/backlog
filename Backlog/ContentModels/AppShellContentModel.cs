using Backlog.Services;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

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
            contentModel.Title = "BackLog App";
            contentModel.MenuItems.Add(new
            {
                Link = "/epics",
                Caption = "Epics"
            });
            contentModel.MenuItems.Add(new
            {
                Link = "/epic",
                Caption = "Epic Create"
            });
            return contentModel;
        }
		
        public string Title { get; set; }
        public ICollection<dynamic> MenuItems { get; set; } = new HashSet<dynamic>();

		[JsonConverter(typeof(StringEnumConverter))]
		public ContentModelType ContentModelType { get; set; } = ContentModelType.AppShell;

        protected readonly ICache _cache;
    }
}
