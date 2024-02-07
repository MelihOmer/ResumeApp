namespace ResumeApp.Core.Dtos.ExperienceDtos
{
    public record class ExperienceUpdateDto
    {
        public int Id { get; init; }
        public string CompanyName { get; init; }
        public string About { get; init; }
        public string Skills { get; init; }
        public int ResumeId { get; init; }
        public DateTime StartDate { get; init; } = DateTime.Now;
        public DateTime EndDate { get; init; } = DateTime.Now;
        public bool Continue { get; init; }
    }
}
