namespace ResumeApp.Core.Dtos
{
    public record ResumeCreateDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string Address { get; init; }
        public string WebSiteUrl { get; init; }
        public string LinkedinUrl { get; init; }
        public string TwitterUrl { get; init; }
        public string FacebookUrl { get; init; }
        public string GithubUrl { get; init; }
        public string YoutubeChannelUrl { get; init; }
    }
}
