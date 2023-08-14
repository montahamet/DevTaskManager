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

namespace STAGE._2023.TEST.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            ProjectViewModel _Model = new ProjectViewModel();
            _Model.Projects = Repository.Project.GetAll();
            return View(_Model);
        }
    
    public ActionResult Add()

    {

            ProjectViewModel Model = new ProjectViewModel();

            Model.StatusProjects = Repository.Config.GetAllStatusProject();

            return View(Model);
    }

        [HttpPost]

        public IActionResult Add(ProjectViewModel viewModel)
    {
        {
                {
                    if (ModelState.IsValid)
                        try
                        {

                            var project = new Entities.Project
                            {

                                project_name = viewModel.project_name,
                                project_module = viewModel.project_module,
                                project_version = viewModel.project_version,
                                project_description = viewModel.project_description,
                                project_leader = viewModel.project_leader,
                                project_estimated_budget = viewModel.project_estimated_budget,
                                project_total_amount = viewModel.project_total_amount,
                                project_estimated_duration = viewModel.project_estimated_duration,
                                StatusProject = new StatusProject() { id_StatusProject = viewModel.id_StatusProject }
                                

                            };
                            Repository.Project.Add(project);
                            return RedirectToAction(nameof(Index));
                        }
                        catch (Exception ex)
                        {
                            return View(ex.Message);
                        }
                }
                ModelState.AddModelError("", "Error");

                ProjectViewModel Model = new ProjectViewModel();

                Model.StatusProjects = Repository.Config.GetAllStatusProject();
                return View(Model);
            }
        }
        public IActionResult Edit(int id_project)
    {

        var project = Repository.Project.Getone(id_project);
        

            try
        {
                Models.ProjectViewModel _Model = new Models.ProjectViewModel
            
            {
                id_project = project.id_project,
                project_name = project.project_name,
                project_module = project.project_module,
                project_version = project.project_version,
                project_description = project.project_description,
                project_leader = project.project_leader,
                project_estimated_budget = project.project_estimated_budget,
                project_total_amount = project.project_total_amount,
                project_estimated_duration = project.project_estimated_duration,
                StatusProjects = Repository.Config.GetAllStatusProject(),
                Project = project,
            };

            return View(_Model);
        }
        catch (Exception ex)
        {
            ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("Project.Edit ", Environment.NewLine, ex.Message) };
            return RedirectToAction("Error", "Errors", _EModel);
        }


    }



    [HttpPost]
    public IActionResult Edit(ProjectViewModel viewModel)
    {
        {
            if (ModelState.IsValid)
                try
                {
                    

                    var project = new Entities.Project
                    {
                        id_project = viewModel.id_project,
                        project_name = viewModel.project_name,
                        project_module = viewModel.project_module,
                        project_version = viewModel.project_version,
                        project_description = viewModel.project_description,
                        project_leader = viewModel.project_leader,
                        project_estimated_budget = viewModel.project_estimated_budget,
                        project_total_amount = viewModel.project_total_amount,
                        project_estimated_duration = viewModel.project_estimated_duration,
                        StatusProject = new StatusProject() { id_StatusProject = viewModel.id_StatusProject },
                        

                    };
                    Repository.Project.Update(project);
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

    [HttpPost]

    public bool Delete(int id_project)
    {
        try
        {
            var project = Repository.Project.Getone(id_project);
            Repository.Project.Remove(project);
                return true;
            }

        catch (System.Exception)
        {
            return false;
        }
    }
    public ActionResult Details(int id_project)
    {
        var project = Repository.Project.Getone(id_project);
        if (project == null)
        {
            return RedirectToAction(nameof(Index));
        }

        Models.ProjectViewModel _Model = new Models.ProjectViewModel()
        {
            id_project=project.id_project,
            project_name = project.project_name,
            project_module = project.project_module,
            project_version = project.project_version,
            project_description = project.project_description,
            project_leader = project.project_leader,
            project_estimated_budget = project.project_estimated_budget,
            project_total_amount = project.project_total_amount,
            project_estimated_duration = project.project_estimated_duration,
            StatusProjects = Repository.Config.GetAllStatusProject()

        };
        return View(_Model);
    }
    }
}

