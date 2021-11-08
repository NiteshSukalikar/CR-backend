using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IEH_Shared.Utility
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailAttachmentAsync(string email, string subject, byte[] attachment, string fileName, string contentType, string message);
        Task<bool> sendEmail(String email, String subject, String message);

    }
}
