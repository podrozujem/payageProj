using System;

namespace HospitalLibrary.Middleware.Model
{
    public class NotExistingUserAccountException : Exception
    {
        public NotExistingUserAccountException() : base()
        {
        }
    }
}
