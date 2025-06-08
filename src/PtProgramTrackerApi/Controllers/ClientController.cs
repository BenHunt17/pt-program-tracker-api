using Microsoft.AspNetCore.Mvc;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs;
using PtProgramTrackerApi.Domain.Interfaces.Services;
using System.Net;

namespace PtProgramtrackerApi.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
        public IActionResult GetById(int id)
        {
            var client = _clientService.GetClient(id);
            return Ok(client);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Client>), (int)HttpStatusCode.OK)]
        public IActionResult FindAll()
        {
            var clients = _clientService.GetClients();
            return Ok(clients);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.Created)]
        public IActionResult Add(ClientInput input)
        {
            var client = _clientService.AddClient(input);
            return Created("{id}", client);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
        public IActionResult Update(int id, ClientInput clientInput)
        {
            var client = _clientService.UpdateClient(id, clientInput);
            return Ok(client);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        public IActionResult Delete(int id)
        {
            _clientService.DeleteClient(id);
            return NoContent();
        }
    }
}
