using Service.Bootstrapper;
using Service.Data.Implementation;
using Service.Data.Interface;

namespace Service
{
    public static class BootStrapper
    {
        public static void Initialize()
        {
            IocContainer.RegisterSingletonInstance<IDataStore>(new DataStore());
            IocContainer.RegisterType<IDataContext, DataContext>();
        }
    }
}