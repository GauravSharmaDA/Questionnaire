using Raven.Client;
using Service.Data.Interface;

namespace Service.Data.Implementation
{
    public class DataContext : IDataContext
    {
        public DataContext(IDataStore dataStore)
        {
            Session = dataStore.Db.OpenSession();
        }

        public void Dispose()
        {
            if (Session != null)
            {
                this.Session.SaveChanges();
                this.Session.Dispose();
            }
        }

        public IDocumentSession Session { get; set; }
    }
}