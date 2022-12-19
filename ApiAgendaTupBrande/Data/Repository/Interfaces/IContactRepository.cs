using ApiAgendaTupBrande.Entities;

namespace ApiAgendaTupBrande.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetListContacts();
        Task<Contact> GetContactById(int id);
        Task DeleteContact(Contact contact);
        Task<Contact> AddContact(Contact contact);
        Task UpdateContact(Contact contact);   
    }
}
