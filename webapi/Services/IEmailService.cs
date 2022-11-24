using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Services
{
    public interface IEmailService
    {
        public void SendEmail
        (
            string From,
            string To,
            string Subject,
            string Message
        );
    }
}