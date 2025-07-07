using PtProgramTrackerApi.DataPersistence.Models;

namespace PtProgramTrackerApi.DataPersistence.QueryExtensions
{
    public static class Filters
    {
        public static IQueryable<ProgramModel> WithClientFilter(this IQueryable<ProgramModel> query, int? clientId)
        {
            return query.Where(x => x.ClientId == null || x.ClientId == clientId);
        }
    }
}
