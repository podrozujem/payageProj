using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Dto.user
{
    public class UserEmailDtos
    {
        public List<UserEmailDto > UserEmails { get; set; }

        public UserEmailDtos()
        {
            UserEmails = new List<UserEmailDto>();
        }
    }
}
