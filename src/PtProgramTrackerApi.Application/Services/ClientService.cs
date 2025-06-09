using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs;
using PtProgramTrackerApi.Domain.Interfaces.DataAccess;
using PtProgramTrackerApi.Domain.Interfaces.Services;

namespace PtProgramTrackerApi.Application.Services
{
    public class ClientService : IClientService
    {
        //TODO - add service layer validators

        private readonly IClientDataAccess _clientDataAccess;

        public ClientService(IClientDataAccess clientDataAccess)
        {
            _clientDataAccess = clientDataAccess;
        }

        public Client GetById(int id)
        {
            return _clientDataAccess.GetById(id);
        }

        public IEnumerable<Client> FindAll()
        {
            return _clientDataAccess.FindAll();
        }

        public Client Create(ClientInput input)
        {
            var client = input.ToDomainEntity();

            return _clientDataAccess.Add(client);
        }

        public Client Update(int id, ClientInput input)
        {
            var client = input.ToDomainEntity();

            return _clientDataAccess.Update(id, client);
        }

        public void Delete(int id)
        {
            _clientDataAccess.Remove(id);
        }
    }
}
