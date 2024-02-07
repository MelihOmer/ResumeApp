using AutoMapper;
using ResumeApp.Core.Contracts;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.SkillsDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Service.Services
{
    public class SkillService : GenericService<Skill>, ISkillService
    {
        private readonly IMapper _mapper;
        public SkillService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task AddSkill(SkillCreateDto dto, int resumeId)
        {
            var entity = _mapper.Map<Skill>(dto);
            entity.ResumeId = resumeId;
            await AddAsync(entity);
        }
        public async Task<SkillUpdateDto> GetSkillUpdate(int Id)
        {
            var skill = await GetById(Id);
            return _mapper.Map<SkillUpdateDto>(skill);
        }
        public async Task UpdateSkill(SkillUpdateDto dto)
        {
            var skill = _mapper.Map<Skill>(dto);
            await Update(skill);
        }
        public async Task RemoveSkill(int id)
        {
            var skill = await GetById(id);
            await Delete(skill);
        }
    }
}
