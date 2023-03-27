using CrudColorado.Application.Service.Interface;
using CrudColorado.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudColorado.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;
        public ClientsController(IClientService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obter todos os clientes
        /// </summary>
        /// <returns>Coleção de clientes</returns>
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAll()
        {
            List<Client> ClientsFromService = await _service.GetAll();
            return Ok(ClientsFromService);
        }

        /// <summary>
        /// Obter cliente por id
        /// </summary>
        /// <returns>Cliente encontrado pelo id informado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Client>>> GetByID(int id)
        {
            Client client = await _service.GetById(id);
            return Ok(client);
        }

        /// <summary>
        /// Cadastrar um cliente
        /// </summary>
        /// <returns>Cliente recém-criado</returns>
        [HttpPost]
        public async Task<ActionResult<Client>> Create([FromBody] Client client)
        {
            Client clientCreated = await _service.Create(client);
            return Ok(clientCreated);
        }

        /// <summary>
        /// Alterar o cliente
        /// </summary>
        /// <returns>Cliente alterado</returns>
        [HttpPut()]
        public async Task<ActionResult<Client>> Update([FromForm] Client client)
        {
            Client clientUpdated = await _service.Update(client);
            return Ok(clientUpdated);
        }

        /// <summary>
        /// Alterar o cliente
        /// </summary>
        /// <returns>Cliente alterado</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            bool clientRemoved = await _service.Delete( id);
            return Ok(clientRemoved);
        }
    }
}
