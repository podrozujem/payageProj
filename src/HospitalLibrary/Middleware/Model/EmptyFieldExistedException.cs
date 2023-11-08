using System;

namespace HospitalLibrary.Middleware.Model
{
    public class EmptyFieldExistedException : Exception
    {
        public EmptyFieldExistedException() : base()
        {
        }
    }
}
