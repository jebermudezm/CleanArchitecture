using Application.Dto;

namespace Application.Interfaces
{
    public interface IContactService
    {
        Task<int> Create(ContactDto contact);
        Task<IEnumerable<ContactDto>> GetAll();
        Task<ContactDto> GetById(int id);
        Task<int> Update(ContactDto contact);
        Task<int> Delete(int id);

    }
}
