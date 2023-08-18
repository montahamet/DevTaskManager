using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using STAGE._2023.TEST.Entities;
using STAGE._2023.TEST.Repository;
using STAGE._2023.TEST.Models;
using System;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.CodeAnalysis;
using STAGE._2023.TEST.DataLayer;

namespace STAGE._2023.TEST.Controllers
{
    public class DevTaskController : Controller
    {
        public IActionResult Index()
        {
            DevTaskViewModel model = new DevTaskViewModel();
            Entities.Project _Project = (HttpContext.Session.GetString("Project") != null)
                                 ? JsonConvert.DeserializeObject<Entities.Project>(HttpContext.Session.GetString("Project"))
                                 : null;
            model.DevTasks = Repository.DevTask.GetAll((_Project != null) ? _Project.id_project : -1);
            return View(model);
        }

        public ActionResult Add(int ModID)

        {

            DevTaskViewModel Model = new DevTaskViewModel();

            Model.TypeDevs = Repository.Config.GetAllTypeDevs();
            Model.PriorityDevs = Repository.Config.GetAllPriorityDevs();
            Model.StatusDevs = Repository.Config.GetAllStatusDevs();
            Model.Projects = Repository.Project.GetAll(ModID);
            Entities.Users _AllUsers = Repository.User.GetAll();

            return View(Model);
        }

        public IActionResult Add(DevTaskViewModel viewModel)
        {
            {
                {
                    if (ModelState.IsValid)
                        try
                        {
                            var devtask = new Entities.DevTask
                            {
                                dev_task_id = viewModel.dev_task_id,
                                id_project = viewModel.id_project ,
                                TypeDev = new TypeDev() { id_TypeDev = viewModel.id_TypeDev },
                                details = viewModel.details,
                                source = viewModel.source,
                                posting_date = viewModel.posting_date,
                                posted_by = viewModel.posted_by,
                                due_date = viewModel.due_date,
                                PriorityDev = new PriorityDev() { id_PriorityDev = viewModel.id_PriorityDev },
                                StatusDev = new StatusDev() { id_StatusDev = viewModel.id_StatusDev },
                                User = new Entities.User() { Id = viewModel.id_user },
                                notes = viewModel.notes


                            };
                            Repository.DevTask.Add(devtask);
                            return RedirectToAction(nameof(Index));
                        }
                        catch (Exception ex)
                        {
                            return View(ex.Message);
                        }
                }
                ModelState.AddModelError("", "Error");

                DevTaskViewModel Model = new DevTaskViewModel();

                Model.TypeDevs = Repository.Config.GetAllTypeDevs();
                Model.PriorityDevs = Repository.Config.GetAllPriorityDevs();
                Model.StatusDevs = Repository.Config.GetAllStatusDevs();
                return View(Model);
            }
        }

        public IActionResult Edit(int ModID, int dev_task_id)
        {

            var devtask = Repository.DevTask.GetOneByID(dev_task_id);
            Entities.Users _AllUsers = Repository.User.GetAll();
            DevTaskViewModel Model = new DevTaskViewModel();

            try
            {
                Models.DevTaskViewModel _Model = new Models.DevTaskViewModel

                {
                    dev_task_id = devtask.dev_task_id,
                    Projects = Repository.Project.GetAll(ModID),
                    TypeDevs = Repository.Config.GetAllTypeDevs(),
                    details = devtask.details,
                    source = devtask.source,
                    posting_date = devtask.posting_date,
                    posted_by = devtask.posted_by,
                    due_date = devtask.due_date,
                    PriorityDevs = Repository.Config.GetAllPriorityDevs(),
                    StatusDevs = Repository.Config.GetAllStatusDevs(),
                    Users = new Entities.Users(_AllUsers.Where(u => u.UserRole.Id == (int)Entities.Enumeration.UserRole.DEVELOPER).ToList()),
                    notes = devtask.notes,
                    DevTask = devtask,
                    
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("DevTask.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }

        }
        public IActionResult Edit(DevTaskViewModel viewModel)
        {
            {
                if (ModelState.IsValid)
                    try
                    {
                        var devtask = new Entities.DevTask
                        {

                            dev_task_id = viewModel.dev_task_id,
                            id_project = viewModel.id_project,
                            TypeDev = new TypeDev() { id_TypeDev = viewModel.id_TypeDev },
                            details = viewModel.details,
                            source = viewModel.source,
                            posting_date = viewModel.posting_date,
                            posted_by = viewModel.posted_by,
                            due_date = viewModel.due_date,
                            PriorityDev = new PriorityDev() { id_PriorityDev = viewModel.id_PriorityDev },
                            StatusDev = new StatusDev() { id_StatusDev = viewModel.id_StatusDev },
                            User = new Entities.User() { Id = viewModel.id_user },
                            notes = viewModel.notes

                        };
                        Repository.DevTask.Update(devtask);
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        return View(ex.Message);
                    }
            }
            ModelState.AddModelError("", "Error");
            return View();
        }

        public bool Delete(int dev_task_id)
        {
            try
            {
                var devtask = Repository.DevTask.GetOneByID(dev_task_id);
                return Repository.DevTask.Remove(devtask);
            }

            catch (System.Exception)
            {
                return false;
            }
        }
        public ActionResult Details(int ModID, int dev_task_id)
        {
            var devtask = Repository.DevTask.GetOneByID(dev_task_id);
            if (devtask == null)
            {
                return RedirectToAction(nameof(Index));
            }

            Models.DevTaskViewModel _Model = new Models.DevTaskViewModel()
            {
                dev_task_id = devtask.dev_task_id,
                Projects = Repository.Project.GetAll(ModID),
                TypeDevs = Repository.Config.GetAllTypeDevs(),
                details = devtask.details,
                source = devtask.source,
                posting_date = devtask.posting_date,
                posted_by = devtask.posted_by,
                due_date = devtask.due_date,
                PriorityDevs = Repository.Config.GetAllPriorityDevs(),
                StatusDevs = Repository.Config.GetAllStatusDevs(),
                Users = Repository.User.GetAll(),
                notes = devtask.notes,
                DevTask = devtask,

            };
            return View(_Model);
        }


    }
}
