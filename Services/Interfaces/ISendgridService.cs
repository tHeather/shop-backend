using System.Threading.Tasks;

namespace shop_backend.Services.Interfaces
{
    public interface ISendgridService
    {
        Task SendPasswordResetLink(string recipientMail, string resetLink);
        Task SendConfirmEmailAddressLink(string recipientMail, string confirmationLink);
    }
}
