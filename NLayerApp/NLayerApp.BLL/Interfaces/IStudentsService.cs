using NLayerApp.BLL.DTO;
using System.Collections.Generic;

namespace NLayerApp.BLL.Interfaces
{
    public interface IStudentsService
    {

        void CreateGroup(GroupDTO groupDTO);
        GroupDTO GetGroup(int? id);
        GroupDTO UpdateGroup(GroupDTO groupDTO);
        void DeleteGroup(int? id);
        IEnumerable<GroupDTO> GetGroups();

        IEnumerable<StudentDTO> GetStudents();
        void CreateStudent(StudentDTO studentDTO);
        StudentDTO GetStudent(int? id);
        StudentDTO UpdateStudent(StudentDTO studentDTO);
        void DeleteStudent(int? id);

        void Dispose();
    }
}
