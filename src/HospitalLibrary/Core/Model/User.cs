
using System;

namespace HospitalLibrary.Core.Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public UserType Type { get; set; }
        
        public bool RequirePasswordChange { get; set; }
    }
}