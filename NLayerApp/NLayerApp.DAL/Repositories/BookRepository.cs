﻿using System;
using System.Collections.Generic;
using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using System.Data.Entity;

namespace NLayerApp.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private MainContext db;

        public BookRepository(MainContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Book> Find(Func<Book, Boolean> predicate)
        {
            return db.Books.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
    }
}
