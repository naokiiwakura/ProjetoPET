using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPET.Models
{
   public  interface IEmailSender
    {
        Task<bool> EnviarEmail(string fromAddress, string toAddress, string subject, string content);

    }
}
