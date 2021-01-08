using System;
namespace shop_backend.Database.Entities
{
    public class FooterSettings
    {
        public int Id { get; set; }
        public string WeekWorkingHours { get; set; }
        public string WeekendWorkingHours { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
    }
}
