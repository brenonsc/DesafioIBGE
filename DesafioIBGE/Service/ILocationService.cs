using DesafioIBGE.Model;

namespace DesafioIBGE.Service;

public interface ILocationService
{
        Task<IEnumerable<Location>>  GetAllLocations();
        Task<Location?> GetLocationById(string id);
        Task<IEnumerable<Location>> GetLocationsByCity(string city);
        Task<IEnumerable<Location>> GetLocationsByState(string state);
        Task <Location?> CreateLocation(Location location);
        Task<Location?> UpdateLocation(Location location);
        Task<Location?> DeleteLocation(string id);
}
    
