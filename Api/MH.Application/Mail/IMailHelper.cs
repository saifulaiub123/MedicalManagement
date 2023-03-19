﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Application.Mail
{
    public interface IMailHelper
    {
        Task SendEmail(string sendTo, string subject, string body);
    }
}
