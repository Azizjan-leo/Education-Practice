using NLayerApp.DAL.Entities;
using System;

namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Group> Groups { get; }
        IRepository<Student> Students { get; }
        IRepository<Book> Books { get; }
        IRepository<BookLease> BookLeases { get; }
        void Save();
    }
}
