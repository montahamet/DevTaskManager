using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities.Enumeration
{
    public static class Enumeration
    {
        public enum UserRole
        {
            ADMIN = 1,
            DEVELOPER
        }
        public enum TypeDev
        {
            NEW_DEV = 1,
            BUG_FIX,
            IMPROVEMENT,
            NEW_INSTALL
        }
        public enum PriorityDev
        {
            LOW = 1,
            MEDIUM,
            HIGH,
            URGENT
        }
        public enum StatusDev
        {
            NOT_STARTED = 1,
            IN_PROGRESS,
            COMPLETED,
            DELAYED,
            CANCELED,
            ARCHIVED
        }
        public enum StatusProject
        {
            IN_PROGRESS = 1,
            ON_HOLD,
            SUCCESS,
            DELAYED,
            CANCELED,
            APPROVAL_PENDING,
            READY_FOR_RELEASE,
            TESTING
        }

    }
}
