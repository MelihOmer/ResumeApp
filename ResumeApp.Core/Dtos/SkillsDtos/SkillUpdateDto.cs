namespace ResumeApp.Core.Dtos.SkillsDtos
{
    public record SkillUpdateDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int ResumeId { get; init; }
    }
}
