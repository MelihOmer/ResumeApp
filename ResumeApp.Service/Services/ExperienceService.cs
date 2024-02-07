using AutoMapper;
using ResumeApp.Core.Contracts;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.ExperienceDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Service.Services
{
    public class ExperienceService : GenericService<Experience>, IExperienceService
    {
        private readonly IMapper _mapper;
        public ExperienceService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task AddExperience(ExperienceAddDto dto, int Id)
        {
            var entity = _mapper.Map<Experience>(dto);
            entity.ResumeId = Id;
            await AddAsync(entity);
        }
        public async Task<ExperienceUpdateDto> GetExperienceUpdate(int Id)
        {
            var entity = await GetById(Id);
            return _mapper.Map<ExperienceUpdateDto>(entity);
        }
        public async Task UpdateExperience(ExperienceUpdateDto updateDto)
        {
            var experience = _mapper.Map<Experience>(updateDto);
            await Update(experience);
        }
        public async Task RemoveExperience(int id)
        {
            var experience = await GetById(id);
            await Delete(experience);
        }
             

    }
}
