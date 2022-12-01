using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Common.Constants
{
    public static class GlobalConstants
    {
        public static class DataFormating
        {
            public const string NormalDateFormat = "dd.mm.yyyy";
        }

        public static class Regex
        {
            public const string PhoneNumberRegex = @"^\d{10}$";
        }

        public static class UserRoles
        {
            public const string Administrator = "Administrator";
        }

        public static class Messages
        {
            public const string Success = "Success";
            public const string Error = "Error";
        }
    }
}
