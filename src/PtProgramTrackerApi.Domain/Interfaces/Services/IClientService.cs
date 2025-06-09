using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Inputs;

namespace PtProgramTrackerApi.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Client GetById(int id);

        IEnumerable<Client> FindAll();

        Client Create(ClientInput input);

        Client Update(int id, ClientInput input);

        void Delete(int id);
    }
}
