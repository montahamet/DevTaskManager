using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STAGE._2023.TEST.API;
using STAGE._2023.TEST.Entities;


namespace STAGE._2023.TEST.API.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{

    private IConfiguration configuration;

    public ProjectController(IConfiguration iConfig)
    {
        configuration = iConfig;
    }

    [HttpGet]
    [Route("GetProjects")]
    public ApiResponse GetProjects()
    {
        try
        {
            Entities.Projects _Data = Repository.Project.GetAll();
            if (_Data != null)
            {
                return new ApiResponse
                {
                    Success = true,
                    Error = -1,
                    Message = "Success",
                    Data = _Data
                };
            }
            else
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 2,
                    Message = "No Data Found!!!",
                    Data = null
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse
            {
                Success = false,
                Error = 0,
                Message = ex.Message,
                Data = null
            };
        }
    }

    [HttpGet]
    [Route("GetProjectById")]
    public ApiResponse Getone(int id_project)
    {
        try
        {
            Entities.Project _Data = Repository.Project.Getone(id_project);
            if (_Data != null)
            {
                return new ApiResponse
                {
                    Success = true,
                    Error = -1,
                    Message = "Success",
                    Data = _Data
                };
            }
            else
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 2,
                    Message = "No Data Found!!!",
                    Data = null
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse
            {
                Success = false,
                Error = 0,
                Message = ex.Message,
                Data = null
            };
        }
    }



    [HttpPost]
    [Route("AddProject")]
    public ApiResponse AddProject(Entities.Project project)
    {
        try
        {
            bool _Success = Repository.Project.Add(project);

            return new ApiResponse
            {
                Success = _Success,
                Error = _Success ? -1 : 1,
                Message = _Success ? "Success" : "User Add Failed!!!!!!",
                Data = null
            };

        }
        catch (Exception ex)
        {
            return new ApiResponse
            {
                Success = false,
                Error = 0,
                Message = ex.Message,
                Data = null
            };
        }
    }

    [HttpPost]
    [Route("UpdateProject")]
    public ApiResponse UpdateUser(Entities.Project project)
    {
        try
        {
            bool _Success = Repository.Project.Update(project);

            return new ApiResponse
            {
                Success = _Success,
                Error = _Success ? -1 : 1,
                Message = _Success ? "Success" : "User Update Failed!!!",
                Data = null
            };

        }
        catch (Exception ex)
        {
            return new ApiResponse
            {
                Success = false,
                Error = 0,
                Message = ex.Message,
                Data = null
            };
        }
    }

    [HttpPost]
    [Route("RemoveProject")]
    public ApiResponse RemoveProject(Entities.Project project)
    {
        try
        {
            bool _Success = Repository.Project.Remove(project);

            return new ApiResponse
            {
                Success = _Success,
                Error = _Success ? -1 : 1,
                Message = _Success ? "Success" : "User Delete Failed!!!",
                Data = null
            };

        }
        catch (Exception ex)
        {
            return new ApiResponse
            {
                Success = false,
                Error = 0,
                Message = ex.Message,
                Data = null
            };
        }
    }
}
}
