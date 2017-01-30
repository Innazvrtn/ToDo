using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ActionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}