using NLayerApp.BLL.DTO;
using System.Collections.Generic;

namespace NLayerApp.BLL.Interfaces
{
    public interface ILeaseService
    {
        bool MakeLease(BookLeaseDTO bookLeaseDTO);
        BookDTO GetBook(int? id);
        StudentDTO GetStudent(int? id);
        IEnumerable<BookLeaseDTO> GetLeases();
        IEnumerable<BookDTO> GetBooks();
        void Return(int? id);
        void Dispose();
    }
}