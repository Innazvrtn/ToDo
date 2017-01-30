using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ToDoList.DAL.Entity;

namespace ToDoList.DAL.EF
{
    public class ToDoContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Entity.Action> Actions { get; set; }

        public ToDoContext()
        {
            Database.SetInitializer<ToDoContext>(new StoreDbInitializer());
        }
        public ToDoContext(string con)
                : base(con)
        {
        }
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ToDoContext>
        {
            protected override void Seed(ToDoContext db)
            {
                db.Projects.Add(new Project { Name = "Work" });
                db.Projects.Add(new Project { Name = "Home" });
                db.SaveChanges();
                db.Actions.Add(new Entity.Action { Name="DoTestWork",ProjectId=1});
                db.Actions.Add(new Entity.Action { Name = "Buy product", ProjectId = 2 });

                db.SaveChanges();
            }
        }
    }
}
