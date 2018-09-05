using AutoMapper;
using NLayerApp.BLL.Configuration.MapperConfiguration;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interfaces;
using NLayerApp.WEB.Helpers;
using NLayerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.WEB.Controllers
{
    public class LeasesController : Controller
    {
        ILeaseService leasesService;
        IStudentsService studentsService;
        IBooksService booksService;
        public LeasesController(ILeaseService serv, IStudentsService studServ, IBooksService bookServ)
        {
            leasesService = serv;
            studentsService = studServ;
            booksService = bookServ;
        }
        // GET: Return
        public ActionResult Return(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            leasesService.Return(Id);
            return RedirectToAction("Index");
        }
        // GET: Leases
        public ActionResult Lease(int? Id)
        {
          
            BookDTO bookDTO = booksService.GetBook(Id);
            if(bookDTO != null)
            {
                BookLeaseVM bookLeaseVM = new BookLeaseVM
                {
                    BookId = bookDTO.BookId,
                    Name = bookDTO.Name,
                    Author = bookDTO.Author
                };
                ViewBag.StudentId = new SelectList(studentsService.GetStudents(), "StudentId", "FirstName");
                return View(bookLeaseVM);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Lease(BookLeaseVM bookLeaseVM)
        {
            try
            {
                BookLeaseDTO bookLeaseDTO = new BookLeaseDTO
                {
                    BookId = bookLeaseVM.BookId,
                    StudentId = bookLeaseVM.StudentId,
                    GetTime = DateTime.Now,
                    Amount = bookLeaseVM.Amount
                };
                if(leasesService.MakeLease(bookLeaseDTO))
                    return RedirectToAction("Index");
                return View("Error");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            IEnumerable<BookLeaseDTO> leaseDtos = leasesService.GetLeases();
            var leases = Mapper.Map<List<LeaseListVM>>(leaseDtos);
            return View(leases);
        }
    }
}