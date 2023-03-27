using CrudColorado.Domain;

namespace CrudColorado.Application.Service.Interface
{
    //this is a use case
    public interface IClientService
    {
        Task<List<Client>> GetAll();
        Task<Client> Create(Client client);
        Task<Client> GetById(int id);
        Task<Client> Update(Client client);
        Task<bool> Delete(int idClient);
    }
}
