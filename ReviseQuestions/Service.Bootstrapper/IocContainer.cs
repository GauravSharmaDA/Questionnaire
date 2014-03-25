using StructureMap;

namespace Service.Bootstrapper
{
    public static class IocContainer
    {
        public static void RegisterType<I, T>() where T : I
        {
            ObjectFactory.Container.Configure(x => x.For<I>().Use<T>());
        }

        public static void RegisterSingletonInstance<T>(T instance)
        {
            ObjectFactory.Container.Configure(x => x.For<T>().Singleton().Use(instance));
        }

        public static void RegisterTypeWithAlias<I, T>(string alias) where T : I
        {
            ObjectFactory.Container.Configure(x => x.For<I>().Use<T>().Named(alias));
        }

        public static T ResolveInstance<T>()
        {
            return ObjectFactory.Container.GetInstance<T>();
        }
    }
}
