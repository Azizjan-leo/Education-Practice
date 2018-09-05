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
    public class StudentsService : IStudentsService
    {
        IUnitOfWork Database { get; set; }

        public StudentsService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateGroup(GroupDTO groupDTO)
        {
            Group group = new Group
            {
                Name = groupDTO.Name,
            };

            Database.Groups.Create(group);
            Database.Save();
        }
        

        public IEnumerable<GroupDTO> GetGroups()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Group>, List<GroupDTO>>(Database.Groups.GetAll());
        }

        public GroupDTO GetGroup(int? id)
        {
            if (id == null)
                throw new ValidationException("Group ID is not set", "");
            var group = Database.Groups.Get(id.Value);
            if (group == null)
                throw new ValidationException("The group was not found", "");

            return Mapper.Map<GroupDTO>(group);
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

      


        public void DeleteGroup(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public GroupDTO UpdateGroup(GroupDTO groupDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            var students = Database.Students.GetAll();
            var mappedObj = Mapper.Map<IEnumerable<Student>, List<StudentDTO>>(students);
            return mappedObj;
        }

        public void CreateStudent(StudentDTO studentDTO)
        {
            Student student = new Student
            {
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                GroupId = studentDTO.GroupId
            };

            Database.Students.Create(student);
            Database.Save();
        }

        public StudentDTO UpdateStudent(StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
