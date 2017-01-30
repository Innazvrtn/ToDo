using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.DAL;
using ToDoList.DAL.Entity;
using ToDoList.DAL.Interface;
using ToDoList.DAL.Repository;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Project> dbProject;
        IRepository<DAL.Entity.Action> dbAction;
        public HomeController()
        {
            dbProject = new ProjectRepository();
            dbAction = new ActionRepository();
        }
        public ActionResult Index()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.Entity.Action, ActionViewModel>());
            var toDoList = Mapper.Map<IEnumerable<DAL.Entity.Action>, List<ActionViewModel>>(dbAction.GetAll());

            foreach (ActionViewModel em in toDoList)
            {
                    var nameProject = dbProject.Get(em.ProjectId);
                if (nameProject != null)
                    em.ProjectName = nameProject.Name;
                
            }
            return View(toDoList);
        }

        public ActionResult Create()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectViewModel>());
            var projectList = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(dbProject.GetAll());
            ActionViewModel model = new ActionViewModel();
            model.ProjectId = -1;
            model.Projects = projectList;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ActionViewModel model)
        {
            if (ModelState.IsValid)
            {

                Mapper.Initialize(cfg => cfg.CreateMap<ActionViewModel, DAL.Entity.Action>());
                var staff = Mapper.Map<ActionViewModel, DAL.Entity.Action>(model);

                dbAction.Create(staff);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.Entity.Action, ActionViewModel>());
            ActionViewModel model = Mapper.Map<DAL.Entity.Action, ActionViewModel>(dbAction.Get(id.Value));
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectViewModel>());
            var projectList = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(dbProject.GetAll());
            model.Projects = projectList;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ActionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ActionViewModel, DAL.Entity.Action>());
                var emp = Mapper.Map<ActionViewModel, DAL.Entity.Action>(model);
                dbAction.Update(emp);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Mapper.Initialize(cfg => cfg.CreateMap<DAL.Entity.Action, ActionViewModel>());
            ActionViewModel emp = Mapper.Map<DAL.Entity.Action, ActionViewModel>(dbAction.Get(id.Value));
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(ActionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ActionViewModel, DAL.Entity.Action>());
                var emp = Mapper.Map<ActionViewModel, DAL.Entity.Action>(model);
                dbAction.Delete(emp.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}