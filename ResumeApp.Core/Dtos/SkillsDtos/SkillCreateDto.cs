namespace ResumeApp.Core.Dtos.SkillsDtos
{
    public record SkillCreateDto
    {
        public string Name { get; init; }
        public int ResumeId { get; init; }
    }
}
