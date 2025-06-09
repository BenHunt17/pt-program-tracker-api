using PtProgramTrackerApi.Domain.Entities;

namespace PtProgramTrackerApi.Domain.Interfaces.DataAccess
{
    public interface IClientDataAccess
    {
        Client GetById(int id);

        IEnumerable<Client> FindAll();

        Client Add(Client input);

        Client Update(int id, Client input);

        void Remove(int id);
    }
}
