using AutoMapper;
using ResumeApp.Core.Contracts;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Service.Services
{
    public class ResumeService : GenericService<Resume>, IResumeService
    {

        private readonly IMapper _mapper;
        public ResumeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task Add(ResumeCreateDto resumeDto)
        {
            var entity = _mapper.Map<Resume>(resumeDto);
            await AddAsync(entity);
        }
        public async Task Update(ResumeUpdateDto updateDto)
        {
            var entity = _mapper.Map<Resume>(updateDto);
            await Update(entity);
        }
        public async Task<List<ResumeDto>> GetAllResume()
        {
            var entityList = await GetAll();
            return _mapper.Map<List<ResumeDto>>(entityList);
        }
        public ResumeUpdateDto GetResumeUpdate(int id)
        {
            var entity = Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<ResumeUpdateDto>(entity);
        }

    }
}
