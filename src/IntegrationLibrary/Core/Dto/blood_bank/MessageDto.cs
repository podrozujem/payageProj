using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Dto.blood_bank
{
    public class MessageDto
    {
        public string Message { get; set; }
        public MessageDto(string message)
        {
            Message = message;
        }
    }
}
