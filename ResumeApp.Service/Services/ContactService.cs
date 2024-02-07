using AutoMapper;
using ResumeApp.Core.Contracts;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos.ContactDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Service.Services
{
    public class ContactService : GenericService<Contact>, IContactService
    {
        private readonly IMapper _mapper;
        public ContactService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<string> SeenMessage(int Id)
        {
            var contact = await GetById(Id);
            if (contact != null )
            {
                if (!contact.Seen)
                {
                    contact.Seen = true;
                    await Update(contact);
                    return $"{Id} Nolu Mesaj Okundu.";
                }
                else
                    return $"{Id} Nolu Mesaj Daha Önce Okunmuş.";
                
            }
            return "Mesaj Bulunamadı";
        }

        public async Task SendMessage(ContactAddDto dto)
        {
            var entity = _mapper.Map<Contact>(dto);
            await AddAsync(entity);
        }
    }
}
