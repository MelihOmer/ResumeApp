using ResumeApp.Core.Common;

namespace ResumeApp.Core.Entities
{
    public class Contact:BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Seen { get; set; }
    }
}
