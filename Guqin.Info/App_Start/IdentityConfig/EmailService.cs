using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Guqin.Info.MVC.App_Start.IdentityConfig
{
    public class EmailService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }
}