﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.email
{
    public interface IEmailService
    {
        void SendDummyPasswordToEmail(string email, string password);
    }
}