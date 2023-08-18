using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IConfiguration configuration;

        public UserController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpGet]
        [Route("GetUsers")]
        public ApiResponse GetUsers()
        {
            try
            {
                Entities.Users _Data = Repository.User.GetAll();
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
        [Route("GetUserById")]
        public ApiResponse GetUserById(int UserID)
        {
            try
            {
                Entities.User _Data = Repository.User.GetOne(UserID);
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
        [Route("GetUserByLogin")]
        public ApiResponse GetUserByLogin(string Login)
        {
            try
            {
                Entities.User _Data = Repository.User.GetOneByLogin(Login);
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
        [Route("UserLogin")]
        public ApiResponse UserLogin(LoginModel User)
        {
            try
            {
                Entities.User _Data = Repository.User.GetOneByLogin(User.Login);
                if (_Data == null)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Error = 2,
                        Message = "No Data Found!!!",
                        Data = null
                    };
                }

                if (!_Data.Authenticate(_Data.Login.Trim(), Utils.Crypto.Encrypt(User.Password, Entities.Constant.CONST_CIPHER_PHRASE)))
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Error = 2,
                        Message = "Password!!!",
                        Data = null
                    };
                }


                return new ApiResponse
                {
                    Success = true,
                    Error = -1,
                    Message = "Success",
                    Data = _Data
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
        [Route("AddUser")]
        public ApiResponse AddUser(Entities.User user)
        {
            try
            {
                bool _Success = Repository.User.Add(user);

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
        [Route("UpdateUser")]
        public ApiResponse UpdateUser(Entities.User user)
        {
            try
            {
                bool _Success = Repository.User.Update(user);

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
        [Route("RemoveUser")]
        public ApiResponse RemoveUser(Entities.User user)
        {
            try
            {
                bool _Success = Repository.User.Remove(user);

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
