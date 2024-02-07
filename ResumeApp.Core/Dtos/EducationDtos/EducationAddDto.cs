namespace ResumeApp.Core.Dtos.EducationDtos
{
    public record EducationAddDto
    {
        public string SchoolName { get; init; }
        public string Branch { get; init; }
        public string About { get; init; }
        public bool Continue { get; set; }
        public DateTime StartDate { get; init; } = DateTime.Now;
        public DateTime EndDate { get; init; } = DateTime.Now;
        public int ResumeId { get; init; }
    }
}
