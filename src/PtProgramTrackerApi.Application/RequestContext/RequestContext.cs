using PtProgramTrackerApi.Domain.Interfaces;

namespace PtProgramTrackerApi.Application.RequestContext
{
    public class RequestContext : IRequestContext
    {
        private static AsyncLocal<RequestContextState> _requestContextState 
            = new AsyncLocal<RequestContextState>();

        public RequestContext()
        {
        }

        public int? ClientId
        {
            get => _requestContextState.Value?.ClientId;
            set => _requestContextState.Value = new RequestContextState
            {
                ClientId = value,
            };
        }
    }
}
