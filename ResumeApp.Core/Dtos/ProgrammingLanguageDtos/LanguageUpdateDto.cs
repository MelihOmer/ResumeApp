namespace ResumeApp.Core.Dtos.ProgrammingLanguageDtos
{
    public record LanguageUpdateDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int ResumeId { get; init; }
    }
}
