using Application.Dto;
using Application.Interfaces;
using EF.UnitOfWork;
using Entities.Entities;
using Mapster;

namespace Application.Service
{

    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Create(ContactDto contact)
        {
            return await _unitOfWork.ContactRepository.Insert(contact.Adapt<Contact>());
        }

        public Task<int> Delete(int id)
        {
            return _unitOfWork.ContactRepository.Delete(id);
        }

        public async Task<IEnumerable<ContactDto>> GetAll()
        {
            var contacts = await Task.Run(() => _unitOfWork.ContactRepository.AsQueryable());
            return contacts.Adapt< IEnumerable<ContactDto>>();
        }

        public async Task<ContactDto> GetById(int id)
        {
            var contact = await Task.Run(() => _unitOfWork.ContactRepository.FirstOrDefault(x => x.Id == id));
            return contact.Adapt<ContactDto>();
        }

        public async Task<int> Update(ContactDto contact)
        {
            return await Task.Run(() => _unitOfWork.ContactRepository.Update(contact.Adapt<Contact>()));
        }
    }
}
