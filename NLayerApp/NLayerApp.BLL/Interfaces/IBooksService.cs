using NLayerApp.BLL.DTO;
using System.Collections.Generic;

namespace NLayerApp.BLL.Interfaces
{
    public interface IBooksService
    {
        void CreateBook(BookDTO bookDTO);
        BookDTO GetBook(int? id);
        BookDTO UpdateBook(BookDTO bookDTO);
        void DeleteBook(int? id);
        IEnumerable<BookDTO> GetBooks();

        void Dispose();
    }
}
