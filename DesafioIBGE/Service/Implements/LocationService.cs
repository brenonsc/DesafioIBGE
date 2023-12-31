using DesafioIBGE.Data;
using DesafioIBGE.Model;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace DesafioIBGE.Service.Implements;

public class LocationService : ILocationService
{
    private readonly AppDbContext _context;
    
    public LocationService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Location>> GetAllLocations()
    {
        var locations = await _context.Locations
            .AsNoTracking()
            .OrderBy(x => x.city)
            .ToListAsync();

        return locations;    
    }

    public async Task<Location?> GetLocationById(string id)
    {
        try
        {
            var locations =  await _context.Locations
                .FirstAsync(i => i.id == id);   

        return locations;
        }
        catch (Exception e)
        {
            return null;
        }

    }

    public async Task<IEnumerable<Location>> GetLocationsByCity(string city)
    {
        var searchCity =  city.ToLower();
        
        var locations = await _context.Locations
            .Where(x => x.city.ToLower().Contains(searchCity)) 
            .OrderBy(x => x.city)
            .ToListAsync();

        return locations;
    }

    public async Task<IEnumerable<Location>> GetLocationsByState(string state)
    {
        var searchState =  state.ToUpper();
        
        var locations = await _context.Locations
            .Where(x => x.state.Contains(searchState))
            .OrderBy(x => x.city)
            .ToListAsync();
       
        return locations;
    }

    public async Task<Location?> CreateLocation(Location location)
    {
        try
        {
            if (await _context.Locations.AnyAsync(x => x.id == location.id))
            {
                throw new Exception("Uma localidade com o mesmo ID já existe no banco de dados.");
            }
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return location;
        }
        catch (Exception ex)
        {
            return null; 
        }
    }


    public async Task<Location?> UpdateLocation(Location location)
    {
        var locationUpdate = await _context.Locations.FindAsync(location.id);

        if (locationUpdate == null)
            return null;
        
        _context.Entry(locationUpdate).State = EntityState.Detached;
        _context.Entry(location).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return location;
    }

    public async Task<Location?> DeleteLocation(string id)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.id == id);

        if (location == null) 
            return null;

        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();

        return location;
    }
}