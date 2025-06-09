using PtProgramTrackerApi.DataPersistence.Models;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Interfaces.DataAccess;
namespace PtProgramTrackerApi.DataPersistence.DataAccess
{
    public class ClientDataAccess : IClientDataAccess
    {
        private readonly DataContext _dataContext;

        public ClientDataAccess(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Client GetById(int id)
        {
            return GetClientById(id).ToDomainEntity();
        }

        public IEnumerable<Client> FindAll()
        {
            return _dataContext.Clients.Select(x => x.ToDomainEntity())
                .ToList();
        }

        public Client Add(Client client)
        {
            var clientToAdd = new ClientModel(client);

            _dataContext.Clients.Add(clientToAdd);

            _dataContext.SaveChanges();

            return clientToAdd.ToDomainEntity();
        }

        public Client Update(int id, Client client)
        {
            var clientToUpdate = GetClientById(id);

            client.FirstName = client.FirstName;
            client.LastName = client.LastName;
            client.DateOfBirth = client.DateOfBirth;
            client.Height = client.Height;
            client.Weight = client.Weight;
            client.Email = client.Email;
            client.PhoneNumber = client.PhoneNumber;
            client.FitnessGoal = client.FitnessGoal;
            client.AdditionalNotes = client.AdditionalNotes;

            _dataContext.SaveChanges();

            return clientToUpdate.ToDomainEntity();
        }

        public void Remove(int id)
        {
            var clientToRemove = GetClientById(id);

            _dataContext.Clients.Remove(clientToRemove);

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
