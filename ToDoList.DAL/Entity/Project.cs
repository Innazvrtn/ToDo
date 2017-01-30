using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DAL.Entity
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Action> Actions { get; set; }
    }
}
