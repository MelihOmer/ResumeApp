namespace ResumeApp.Core.Dtos
{
    public record ResumeDto
    {
        public int Id { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string Address { get; init; }
    }
}
