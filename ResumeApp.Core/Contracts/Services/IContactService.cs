using ResumeApp.Core.Dtos.ContactDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Core.Contracts.Services
{
    public interface IContactService : IGenericService<Contact>
    {
        Task SendMessage(ContactAddDto dto);
        Task<string> SeenMessage(int Id);
    }
}
