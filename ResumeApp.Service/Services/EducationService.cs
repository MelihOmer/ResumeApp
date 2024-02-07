using AutoMapper;
using ResumeApp.Core.Contracts;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.EducationDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Service.Services
{
    public class EducationService : GenericService<Education>, IEducationService
    {
        private readonly IMapper _mapper;
        public EducationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task AddEducation(EducationAddDto dto, int resumeId)
        {
            var entity = _mapper.Map<Education>(dto);
            entity.ResumeId = resumeId;
            await AddAsync(entity);
        }

        public async Task<EducationUpdateDto> GetEducationUpdate(int Id)
        {
            var education = await GetById(Id);
            return _mapper.Map<EducationUpdateDto>(education);
        }
        public async Task EducationUpdate(EducationUpdateDto eduDto)
        {
            var education = _mapper.Map<Education>(eduDto);
            await Update(education);
        }
        public async Task RemoveEducation(int id)
        {
            var education = await GetById(id);
            await Delete(education);

        }
    }
}
