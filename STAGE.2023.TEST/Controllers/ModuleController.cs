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
using System.Collections.Generic;

namespace STAGE._2023.TEST.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult Index(int ModID, int ProjID = -1)
        {
            ModuleViewModel _Model = new ModuleViewModel();
            _Model.Projects = Repository.Project.GetAll(ModID);
            _Model.DevTasks = Repository.DevTask.GetAll(ModID, ProjID);

            return View(_Model);
        }

        public ActionResult Add()
        {
            ModuleViewModel Model = new ModuleViewModel();
            return View(Model);
        }
        public IActionResult Add(ModuleViewModel viewModel)
        {

            {
                if (ModelState.IsValid)
                    try
                    {
                        var module = new Entities.Module
                        {

                            module_id = viewModel.module_id,
                            module_name = viewModel.module_name
                        };
                        Repository.Module.Add(module);
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
        public IActionResult Edit(int module_id)
        {

            Entities.Module module = Repository.Module.GetOneByID(module_id);

            try
            {
                Models.ModuleViewModel _Model = new Models.ModuleViewModel

                {
                    module_id = module.module_id,
                    module_name = module.module_name,
                    Module = module,
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("Module.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }
        }
        public IActionResult Edit(ModuleViewModel viewModel)
        {
            {
                if (ModelState.IsValid)
                    try
                    {
                        var module = new Entities.Module
                        {
                            module_id = viewModel.module_id,
                            module_name = viewModel.module_name,

                        };
                        Repository.Module.Update(module);
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
        public bool Delete(int module_id)
        {
            try
            {
                var module = Repository.Module.GetOneByID(module_id);
                Repository.Module.Remove(module);
                return true;
            }

            catch (System.Exception)
            {
                return false;
            }
        }
        public ActionResult Details(int module_id)
        {
            var module = Repository.Module.GetOneByID(module_id);
            if (module == null)
            {
                return RedirectToAction(nameof(Index));
            }

            Models.ModuleViewModel _Model = new Models.ModuleViewModel()
            {
                module_id = module.module_id,
                module_name = module.module_name

            };
            return View(_Model);
        }

    }
}
