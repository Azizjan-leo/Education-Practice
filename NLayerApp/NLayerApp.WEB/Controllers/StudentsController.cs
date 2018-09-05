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
using System.Net;

namespace NLayerApp.WEB.Controllers
{
    public class StudentsController : Controller
    {
        IStudentsService studentsService;
        public StudentsController(IStudentsService serv)
        {
            studentsService = serv;
        }

        public ActionResult GroupsList()
        {
            IEnumerable<GroupDTO> groupDtos = studentsService.GetGroups();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupVM>()).CreateMapper();
            var groups = mapper.Map<IEnumerable<GroupDTO>, List<GroupVM>>(groupDtos);
            return View(groups);
        }

        public ActionResult StudentsList()
        {
            IEnumerable<StudentDTO> studentDtos = studentsService.GetStudents(); 

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentListVM>()).CreateMapper();
            var students = Mapper.Map<List<StudentListVM>>(studentDtos);
            return View(students);
        }
        public ActionResult DeleteGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupDTO groupDTO = studentsService.GetGroup(id);
            if (groupDTO == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<GroupVM>(groupDTO));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGroup(/*[Bind(Include = "GroupId,Name")]*/ GroupVM group)
        {
            GroupDTO groupDTO = new GroupDTO
            {
                Name = group.Name
            };

            studentsService.DeleteGroup(group.GroupId);

            return RedirectToAction("GroupsList");

        }

        public ActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(/*[Bind(Include = "GroupId,Name")]*/ GroupVM group)
        {
            GroupDTO groupDTO = new GroupDTO
            {
                Name = group.Name
            };

            studentsService.CreateGroup(groupDTO);
            
                return RedirectToAction("GroupsList");
         
        }

        public ActionResult CreateStudent()
        {

            ViewBag.GroupId = new SelectList(studentsService.GetGroups(), "GroupId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudent(/*[Bind(Include = "GroupId,Name")]*/ StudentVM student)
        {
            StudentDTO studentDTO = new StudentDTO
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupId = student.GroupId
            };

            studentsService.CreateStudent(studentDTO);


            return RedirectToAction("StudentsList");

        }
        protected override void Dispose(bool disposing)
        {
            studentsService.Dispose();
            base.Dispose(disposing);
        }
    }
}
