using System.Threading.Tasks;

namespace shop_backend.Services.Interfaces
{
    public interface ISendgridService
    {
        Task SendOrderConfirmationEmail(string recipientMail, string message);
    }
}
