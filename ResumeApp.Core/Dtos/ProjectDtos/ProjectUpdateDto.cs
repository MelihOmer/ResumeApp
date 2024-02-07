using Microsoft.AspNetCore.Http;

namespace ResumeApp.Core.Dtos.ProjectDtos
{
    public record ProjectUpdateDto
    {
        public int Id { get; init; }
        public string GUID { get; init; }
        public string ProjectName { get; init; }
        public string ProjectDescription { get; init; }
        public string ProjectPath { get; init; }
        public int ResumeId { get; init; }
        public IFormFile file { get; set; }
        public bool FileUpdate { get; set; }

    }
}
