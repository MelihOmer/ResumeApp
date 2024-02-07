namespace ResumeApp.Core.Dtos.ProgrammingLanguageDtos
{
    public record LanguageCreateDto
    {
        public string Name { get; init; }
        public int ResumeId { get; init; }
    }
}
