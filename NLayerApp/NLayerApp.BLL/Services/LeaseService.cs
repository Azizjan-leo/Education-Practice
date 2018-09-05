using System;
using NLayerApp.BLL.DTO;
using NLayerApp.DAL.Entities;
using NLayerApp.BLL.BusinessModels;
using NLayerApp.DAL.Interfaces;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace NLayerApp.BLL.Services
{
    public class LeaseService : ILeaseService
    {
        IUnitOfWork Database { get; set; }

        public LeaseService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public bool MakeLease(BookLeaseDTO bookLeaseDTO)
        {
            Book book = Database.Books.Get(bookLeaseDTO.BookId);

            // валидация
            if (book == null)
                throw new ValidationException("The book was not found", "");
            // check if there is enough books for the order
            if (book.Amount >= bookLeaseDTO.Amount)
            {
                BookLease bookLease = new BookLease
                {
                    Amount = bookLeaseDTO.Amount,
                    StudentId = bookLeaseDTO.StudentId,
                    BookId = bookLeaseDTO.BookId,
                    GetTime = bookLeaseDTO.GetTime,
                    ReturnTime = bookLeaseDTO.ReturnTime
                };
                book.Amount -= bookLeaseDTO.Amount;
                Database.Books.Update(book);
                Database.Save();
                Database.BookLeases.Create(bookLease);
                Database.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<BookLeaseDTO> GetLeases()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookLease, BookLeaseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<BookLease>, List<BookLeaseDTO>>(Database.BookLeases.GetAll());
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(Database.Books.GetAll());
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Group>, List<GroupDTO>>(Database.Groups.GetAll());
        }

        public IEnumerable<BookLeaseDTO> GetBookLeases()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookLease, BookLeaseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<BookLease>, List<BookLeaseDTO>>(Database.BookLeases.GetAll());
        }

        public void Return(int? id)
        {
            if (id == null)
                throw new ValidationException("Lease ID is not set", "");
            var lease = Database.BookLeases.Get(id.Value);
            if (lease == null)
                throw new ValidationException("The lease was not found", "");
            lease.ReturnTime = DateTime.Now;
            Database.BookLeases.Update(lease);
            Database.Save();
            var book = Database.Books.Get(lease.BookId);
            book.Amount += lease.Amount;
            Database.Books.Update(book);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }


        public StudentDTO GetStudent(int? id)
        {
            if (id == null)
                throw new ValidationException("Student ID is not set", "");
            var student = Database.Students.Get(id.Value);
            if (student == null)
                throw new ValidationException("The student was not found", "");

            return new StudentDTO { StudentId = student.StudentId, FirstName = student.FirstName, LastName = student.LastName, GroupId = student.GroupId };
        }

        public BookDTO GetBook(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
