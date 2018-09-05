using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private MainContext db;

        public StudentRepository(MainContext context)
        {
            this.db = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students;
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public void Create(Student student)
        {
            db.Students.Add(student);
        }

        public void Update(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
        }

        public IEnumerable<Student> Find(Func<Student, Boolean> predicate)
        {
            return db.Students.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Student student = db.Students.Find(id);
            if (student != null)
                db.Students.Remove(student);
        }
    }
}
