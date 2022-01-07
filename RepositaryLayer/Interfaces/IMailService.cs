using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Model;

namespace RepositaryLayer.Interfaces
{
    public interface IMailService
    {

        Task SendEmailAsync(Mail_Model mailRequest);

    }
}
