using System.Web.Mvc;
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

            container = new Container(x => x.Scan(o =>
            {
                o.Assembly("MadeUpStats.Data");
                o.Assembly("MadeUpStats.Services");
                o.Assembly("MadeUpStats.Web");
                o.WithDefaultConventions();
                o.AddAllTypesOf<IController>()
                    .NameBy(type => type.Name.ToLowerInvariant().Replace("controller", string.Empty));
            }));
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