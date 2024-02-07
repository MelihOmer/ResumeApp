using ResumeApp.Core.Dtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Core.Contracts.Services
{
    public interface IResumeService : IGenericService<Resume>
    {
        Task Add(ResumeCreateDto resumeDto);
        Task<List<ResumeDto>> GetAllResume();
        Task Update(ResumeUpdateDto updateDto);
        ResumeUpdateDto GetResumeUpdate(int id);
    }
}
