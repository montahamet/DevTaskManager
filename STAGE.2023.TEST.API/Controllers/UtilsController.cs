using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsController : ControllerBase
    {

        private IConfiguration configuration;

        public UtilsController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpPost]
        [Route("SendMail")]
        public ApiResponse SendMail(Entities.MailData data)
        {
            try
            {
                Entities.MailData _Data = new Entities.MailData()
                {
                    ReceiverName = "marwen.boudagga@gmail.com",
                    EmailTo = "marwen.boudagga@gmail.com",
                    SenderName = "developpement@hotixsoft.com",
                    EmailSubject = "EmailSubject",
                    EmailBody = "EmailBody",
                    EmailFrom = "developpement@hotixsoft.com",
                    EmailPass = "Dev@2021",
                    SmtpServer = "mail.bmail.tn",
                    SmtpPort = 465,
                    UseSsl = true,
                    IsHTML = true
                };

                if (_Data != null)
                {
                    bool _Success = STAGE._2023.TEST.Utils.Mailing.sendMailHtml(_Data.ReceiverName, _Data.EmailTo, _Data.SenderName, _Data.EmailSubject, _Data.EmailBody,
                                                                         _Data.EmailFrom, _Data.EmailPass, _Data.SmtpServer, _Data.SmtpPort, _Data.UseSsl, _Data.IsHTML);

                    return new ApiResponse
                    {
                        Success = _Success,
                        Error = _Success ? -1 : 2,
                        Message = _Success ? "Success" : "Send Mail Failed!!!",
                        Data = null
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
    }
}
