using Raven.Client;
using Raven.Client.Document;
using Service.Data.Interface;

namespace Service.Data.Implementation
{
    public class DataStore : IDataStore
    {
        private IDocumentStore _instance;
        private readonly object _lock1 = new object();
        public IDocumentStore Db
        {
            get
            {
                lock(_lock1)
                {
                    if (_instance == null)
                    {
                        Initialize();
                    }
                }
                return _instance;
            }
        }

        private void Initialize()
        {
            _instance = new DocumentStore
                {
                    Url = "http://localhost:6060/",
                    DefaultDatabase = "Questionnaire"
                }.Initialize();
        }
    }
}
