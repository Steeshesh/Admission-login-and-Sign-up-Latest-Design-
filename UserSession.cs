using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public static class UserSession
    {
        public static string Username { get; set; }
        public static int UserID { get; set; }
        public static string UserType { get; set; }

        // Method to clear all session data
        public static void Clear()
        {
            Username = null;
            UserID = 0;
            UserType = null;
        }
    }

}
