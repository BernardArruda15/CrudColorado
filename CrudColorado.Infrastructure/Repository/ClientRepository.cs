using CrudColorado.Domain;
using CrudColorado.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrudColorado.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientDbContext _clientDbContext;

        public ClientRepository(ClientDbContext clientDbContext)
        {
            _clientDbContext = clientDbContext;  
        }

        public async Task<List<Client>> GetAll()
        {
            return await _clientDbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int idClient)
        {
            return await _clientDbContext.Clients.FirstOrDefaultAsync(x => x.Id == idClient);
        }

        public async Task<Client> Create(Client client)
        {
            client.Id = 0;
            await _clientDbContext.Clients.AddAsync(client);
            await _clientDbContext.SaveChangesAsync();
            return client;
        }
        public async Task<Client> Update(Client client)
        {
            Client clientByID = await GetById(client.Id);

            if (clientByID == null)
            {
                throw new Exception($"Cliente id: {client.Id} não foi encontrado no banco de dados.");
            }

            clientByID.Name = client.Name;
            clientByID.Address = client.Address;
            clientByID.City = client.City;
            clientByID.State = client.State;

            _clientDbContext.Clients.Update(clientByID);
            await _clientDbContext.SaveChangesAsync();

            return clientByID;
        }

        public async Task<bool> Delete(int idClient)
        {
            Client clientByID = await GetById(idClient);

            if (clientByID == null)
            {
                throw new Exception($"Cliente id: {idClient} não foi encontrado no banco de dados.");
            }

            _clientDbContext.Clients.Remove(clientByID);
            await _clientDbContext.SaveChangesAsync();

            return true;
        }
    }
}
