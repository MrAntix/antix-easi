using Antix.Services.Models;

namespace Antix.Http
{
    public interface ICreatedResponse :
        IServiceResponseWithData
    {
        string RouteName { get; }
    }
}