using PtProgramTrackerApi.Domain.Interfaces;

namespace PtProgramTrackerApi.Application.RequestContext
{
    internal class RequestContextState : IRequestContext
    {
        public int? ClientId { get; set; }
    }
}
