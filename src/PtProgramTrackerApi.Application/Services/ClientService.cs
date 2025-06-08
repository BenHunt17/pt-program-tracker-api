using PtProgramTrackerApi.DataPersistence;
using PtProgramTrackerApi.DataPersistence.Models;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs;
using PtProgramTrackerApi.Domain.Interfaces.Services;

namespace PtProgramTrackerApi.Application.Services
{
    public class ClientService : IClientService
    {
        //TODO - add service layer validators

        private readonly DataContext _dataContext;

        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Client GetClient(int id)
        {
            return GetClientById(id).ToDomainEntity();
        }

        public IEnumerable<Client> GetClients()
        {
            return _dataContext.Clients.Select(x => x.ToDomainEntity())
                .ToList();
        }

        public Client AddClient(ClientInput input)
        {
            var client = input.ToDomainEntity();
            var model = new ClientModel(client);

            _dataContext.Clients.Add(model);

            _dataContext.SaveChanges();

            return model.ToDomainEntity();
        }

        public Client UpdateClient(int id, ClientInput input)
        {
            var client = GetClientById(id);

            client.FirstName = input.FirstName;
            client.LastName = input.LastName;
            client.DateOfBirth = input.DateOfBirth;
            client.Height = input.Height;
            client.Weight = input.Weight;
            client.Email = input.Email;
            client.PhoneNumber = input.PhoneNumber;
            client.FitnessGoal = input.FitnessGoal;
            client.AdditionalNotes = input.AdditionalNotes;

            _dataContext.SaveChanges();

            return client.ToDomainEntity();
        }

        public void DeleteClient(int id)
        {
            var client = GetClientById(id);

            _dataContext.Clients.Remove(client);

            _dataContext.SaveChanges();
        }

        private ClientModel GetClientById(int id)
        {
            var client = _dataContext.Clients.FirstOrDefault(x => x.Id == id);

            if (client == null)
            {
                throw new KeyNotFoundException($"No client with ID {id} was found");
            }

            return client;
        }
    }
}
