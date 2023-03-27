using CrudColorado.Domain;

namespace CrudColorado.Infrastructure.Repository.Interface
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll();
        Task<Client> GetById(int idClient);
        Task<Client> Create(Client client);
        Task<Client> Update (Client client);
        Task<bool> Delete(int idClient);

    }
}
