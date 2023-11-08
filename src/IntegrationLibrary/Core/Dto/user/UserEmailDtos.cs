using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Dto.user
{
    public class UserEmailDtos
    {
        public List<UserEmailDto > userEmails { get; set; }

        public UserEmailDtos()
        {
            userEmails = new List<UserEmailDto>();
        }
    }
}
