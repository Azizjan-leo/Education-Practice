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
    public class HomeController : Controller
    {
        ILeaseService leaseService;
        public HomeController(ILeaseService serv)
        {
            leaseService = serv;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookList()
        {
            IEnumerable<BookDTO> bookDtos = leaseService.GetBooks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookVM>()).CreateMapper();
            var books = mapper.Map<IEnumerable<BookDTO>, List<BookVM>>(bookDtos);
            return View(books);
        }

        public ActionResult MakeLease(int? id)
        {
            try
            {
                BookDTO book = leaseService.GetBook(id);
                var lease = new BookLeaseVM { BookId = book.BookId };

                return View(lease);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeLease(BookLeaseVM lease)
        {
            try
            {
                var bookLeaseDTO = new BookLeaseDTO { BookId = lease.BookId, Amount = lease.Amount, StudentId = lease.StudentId,
                                                      GetTime = lease.GetTime, ReturnTime = lease.ReturnTime};
                leaseService.MakeLease(bookLeaseDTO);
                return Content("<h2>Done!</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(lease);
        }
        protected override void Dispose(bool disposing)
        {
            leaseService.Dispose();
            base.Dispose(disposing);
        }
    }
}