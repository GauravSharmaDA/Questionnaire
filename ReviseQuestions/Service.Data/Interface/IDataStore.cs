using Raven.Client;

namespace Service.Data.Interface
{
    public interface IDataStore
    {
        IDocumentStore Db { get; }
    }
}