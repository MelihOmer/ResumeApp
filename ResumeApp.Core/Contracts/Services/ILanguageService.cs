using ResumeApp.Core.Dtos.ProgrammingLanguageDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Core.Contracts.Services
{
    public interface ILanguageService : IGenericService<ProgramingLanguage>
    {
        Task AddLanguage(LanguageCreateDto dto,int resumeId);
        Task<LanguageUpdateDto> GetProgrammingLanguageUpdate(int id);
        Task ProgrammingLanguageUpdate(LanguageUpdateDto dto);
        Task RemoveLanguage(int id);
    }
}
