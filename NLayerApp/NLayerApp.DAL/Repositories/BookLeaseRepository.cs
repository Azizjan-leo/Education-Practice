using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NLayerApp.DAL.Repositories
{
    public class BookLeaseRepository : IRepository<BookLease>
    {
        private MainContext db;

        public BookLeaseRepository(MainContext context)
        {
            this.db = context;
        }

        public IEnumerable<BookLease> GetAll()
        {
            return db.BookLeases;
        }

        public BookLease Get(int id)
        {
            return db.BookLeases.Find(id);
        }

        public void Create(BookLease bookLease)
        {
            db.BookLeases.Add(bookLease);
        }

        public void Update(BookLease bookLease)
        {
            db.Entry(bookLease).State = EntityState.Modified;
        }

        public IEnumerable<BookLease> Find(Func<BookLease, Boolean> predicate)
        {
            return db.BookLeases.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            BookLease bookLease = db.BookLeases.Find(id);
            if (bookLease != null)
                db.BookLeases.Remove(bookLease);
        }
    }
}
