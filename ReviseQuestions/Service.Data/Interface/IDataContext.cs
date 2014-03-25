using System;
using Raven.Client;

namespace Service.Data.Interface
{
    public interface IDataContext : IDisposable
    {
        IDocumentSession Session { get; set; }
    }
}
