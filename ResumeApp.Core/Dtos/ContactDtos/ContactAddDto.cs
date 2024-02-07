namespace ResumeApp.Core.Dtos.ContactDtos
{
    public record ContactAddDto
    {
        public string Fullname { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string Message { get; init; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
