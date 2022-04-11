using System.Threading.Tasks;

namespace Petclinic.Services
{
    public interface ICustomEmailSender
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}