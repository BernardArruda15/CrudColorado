using CrudColorado.Application.Service.Interface;
using CrudColorado.Domain;
using CrudColorado.Infrastructure.Repository.Interface;

namespace CrudColorado.Application.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAll()
        {
            List<Client> list = await _clientRepository.GetAll();
            return list;
        }

        public async Task<Client> GetById(int id)
        {
            Client client = await _clientRepository.GetById(id);
            return client;
        }

        public async Task<Client> Create(Client client)
        {
            await _clientRepository.Create(client);
            return client;
        }

        public async Task<bool> Delete(int idClient)
        {
            bool removed = await _clientRepository.Delete(idClient);
            return removed;
        }

        public async Task<Client> Update(Client client)
        {
            Client alterClient = await _clientRepository.Update(client);
            return alterClient;
        }
    }
}

