using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.Infrastructure
{
    public class Constants
    {
        public static string VERSION = "1.0.0-alpha.0";
    }

    public class Roles
    {
        public static string SYSTEM = "[Roles] System";
        public static string PRODUCT = "[Roles] Product";
        public static string DEVELOPMENT = "[Roles] Development";
    }

    public class TaskStatuses
    {
        public static string NOT_STARTED = "[TaskStatuses] Not Started";
        public static string IN_PROGRESS = "[TaskStatuses] In Progress";
        public static string QA = "[TaskStatuses] Quality Assurance";
        public static string COMPLETE = "[TaskStatuses] Complete";
    }
}
