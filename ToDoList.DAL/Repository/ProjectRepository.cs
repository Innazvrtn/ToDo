using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Entity;
using ToDoList.DAL.Interface;
using ToDoList.DAL.EF;

namespace ToDoList.DAL.Repository
{
    public class ProjectRepository : IRepository<Project>
    {
        private ToDoContext db;
        public ProjectRepository()
        {
            this.db = new ToDoContext();
        }
        public void Create(Project item)
        {
            db.Projects.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var pr = db.Projects.Find(id);
            if (pr != null)
            {
                db.Projects.Remove(pr);
            }
            db.SaveChanges();
            
        }

        public IEnumerable<Project> Find(Func<Project, bool> func)
        {
            return db.Projects.Where(func).ToList();
        }

        public Project Get(int? id)
        {
            return db.Projects.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects;
        }

        public void Update(Project item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
