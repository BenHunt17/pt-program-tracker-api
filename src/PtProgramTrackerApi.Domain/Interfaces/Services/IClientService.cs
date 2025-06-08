using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs;

namespace PtProgramTrackerApi.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Client GetClient(int id);

        IEnumerable<Client> GetClients();

        Client AddClient(ClientInput input);

        Client UpdateClient(int id, ClientInput input);

        void DeleteClient(int id);
    }
}
