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
   public class ActionRepository:IRepository<Entity.Action>
    {
        private ToDoContext db;
        public ActionRepository()
        {
            this.db = new ToDoContext();
        }
        public void Create(Entity.Action item)
        {
            db.Actions.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var ac = db.Actions.Find(id);
            if (ac != null)
            {
                db.Actions.Remove(ac);
            }
            db.SaveChanges();

        }

        public IEnumerable<Entity.Action> Find(Func<Entity.Action, bool> func)
        {
            return db.Actions.Where(func).ToList();
        }

        public Entity.Action Get(int? id)
        {
            return db.Actions.Find(id);
        }

        public IEnumerable<Entity.Action> GetAll()
        {
            return db.Actions;
        }

        public void Update(Entity.Action item)
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
