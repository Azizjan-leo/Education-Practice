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
    public class GroupRepository : IRepository<Group>
    {
        private MainContext db;

        public GroupRepository(MainContext context)
        {
            this.db = context;
        }

        public IEnumerable<Group> GetAll()
        {
            return db.Groups;
        }

        public Group Get(int id)
        {
            return db.Groups.Find(id);
        }

        public void Create(Group group)
        {
            db.Groups.Add(group);
        }

        public void Update(Group group)
        {
            db.Entry(group).State = EntityState.Modified;
        }

        public IEnumerable<Group> Find(Func<Group, Boolean> predicate)
        {
            return db.Groups.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Group group = db.Groups.Find(id);
            if (group != null)
                db.Groups.Remove(group);
        }
    }
}
