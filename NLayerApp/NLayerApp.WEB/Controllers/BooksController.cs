using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using AutoMapper;
using NLayerApp.BLL.Infrastructure;

namespace NLayerApp.WEB.Controllers
{
    public class BooksController : Controller
    {
        IBooksService booksService;
        public BooksController(IBooksService serv)
        {
            booksService = serv;
        }
        // GET: Books
        public ActionResult Index()
        {
            IEnumerable<BookDTO> bookDtos = booksService.GetBooks();

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentListVM>()).CreateMapper();
            var books = Mapper.Map<List<BookVM>>(bookDtos);
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

       
        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(BookVM bookVM)
        {
            try
            {
                BookDTO bookDTO = new BookDTO
                {
                    Name = bookVM.Name,
                    Author = bookVM.Author,
                    Amount = bookVM.Amount
                };

                booksService.CreateBook(bookDTO);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
