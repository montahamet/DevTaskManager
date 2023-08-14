using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class MailData
    {
        #region Constructors

        public MailData()
        {

        }

        #endregion

        #region Properties

        public int SmtpPort { get; set; }

        public string ReceiverName { get; set; }
        public string EmailTo { get; set; }
        public string SenderName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailFrom { get; set; }
        public string EmailPass { get; set; }
        public string SmtpServer { get; set; }

        public bool UseSsl { get; set; }
        public bool IsHTML { get; set; }

        #endregion

    }
}