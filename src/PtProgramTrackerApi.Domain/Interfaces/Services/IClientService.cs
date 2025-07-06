using PtProgramTrackerApi.Domain.Dtos;
using PtProgramTrackerApi.Domain.Entities;

namespace PtProgramTrackerApi.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Client GetById(int id);

        IEnumerable<Client> FindAll();

        Client Create(ClientDto input);

        Client Update(int id, ClientDto input);

        void Delete(int id);
    }
}
