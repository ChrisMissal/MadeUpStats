using System.Web.Mvc;
using MadeUpStats.Data;
using MadeUpStats.Services;
using MadeUpStats.Web.Routing;
using MadeUpStats.Web.Services;
using StructureMap;

namespace MadeUpStats.Web
{
    public static class Bootstrapper
    {
        private static Container container;
        private static bool initialized;

        public static void Bootstrap()
        {
            if(initialized) return;

            container = new Container(x => {

                x.ForRequestedType<IMvcConfiguration>().TheDefaultIsConcreteType<MadeUpStatsConfiguration>();
                x.ForRequestedType<IRouteConfigurator>().TheDefaultIsConcreteType<RouteConfigurator>();
                x.ForRequestedType<IControllerFactory>().TheDefaultIsConcreteType<StructureMapControllerFactory>();

                x.ForRequestedType<IStatService>()
                    .TheDefaultIsConcreteType<StatService>()
                    .AsSingletons();
                x.ForRequestedType<IStatRepository>()
                    .TheDefaultIsConcreteType<InMemoryStatRepository>()
                    .AsSingletons();

                x.ForRequestedType<ITagService>()
                    .TheDefaultIsConcreteType<TagService>()
                    .AsSingletons();
                x.ForRequestedType<ITagRepository>()
                    .TheDefaultIsConcreteType<InMemoryTagRepository>()
                    .AsSingletons();

                x.ForRequestedType<IAuthorService>()
                    .TheDefaultIsConcreteType<AuthorService>()
                    .AsSingletons();

                x.ForRequestedType<IUserRepository>()
                    .TheDefaultIsConcreteType<InMemoryUserRepository>()
                    .AsSingletons();

                x.ForRequestedType<IUserSession>()
                    .TheDefaultIsConcreteType<HttpUserSession>()
                    .AlwaysUnique();

                x.ForRequestedType<IFeedService>()
                    .TheDefaultIsConcreteType<FeedService>()
                    .AsSingletons();

                x.ForRequestedType<IMapper>()
                    .TheDefaultIsConcreteType<MadeUpStatsMapper>()
                    .AsSingletons();

                x.ForRequestedType<IUserInterfaceManager>()
                    .TheDefaultIsConcreteType<UserInterfaceManager>()
                    .AsSingletons();

                x.ForRequestedType<IHttpContextProvider>()
                    .TheDefaultIsConcreteType<HttpContextProvider>()
                    .AsSingletons();

                x.Scan(o =>
                    {
                        o.TheCallingAssembly();
                        o.AddAllTypesOf<IController>().NameBy(type => 
                            type.Name.ToLowerInvariant().Replace("controller", string.Empty));
                    });
            });
            initialized = true;
        }

        public static Container Container
        {
            get
            {
                if(!initialized)
                    Bootstrap();

                return container;
            }
        }
    }
}