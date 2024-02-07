using AutoMapper;
using ResumeApp.Core.Contracts;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.ProgrammingLanguageDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Service.Services
{
    public class LanguageService : GenericService<ProgramingLanguage>, ILanguageService
    {
        private readonly IMapper _mapper;
        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task AddLanguage(LanguageCreateDto dto, int resumeId)
        {
            var entity = _mapper.Map<ProgramingLanguage>(dto);
            entity.ResumeId = resumeId;
            await AddAsync(entity);
        }

        public async Task<LanguageUpdateDto> GetProgrammingLanguageUpdate(int id)
        {
            var programmingLanguage = await GetById(id);
            return _mapper.Map<LanguageUpdateDto>(programmingLanguage);
        }
        public async Task ProgrammingLanguageUpdate(LanguageUpdateDto dto)
        {
            var programmingLaguage = _mapper.Map<ProgramingLanguage>(dto);
            await Update(programmingLaguage);
        }
        public async Task RemoveLanguage(int id)
        {
            var language = await GetById(id);
            await Delete(language);
        }
    }
}
