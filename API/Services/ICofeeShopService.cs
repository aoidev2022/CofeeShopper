using API.DTO;

using DataAccess.Data;

using Microsoft.EntityFrameworkCore;

namespace API.Services;

public interface ICofeeShopService
{
    public Task<IEnumerable<CofeeShopDto>> GetAll();
}

public class CofeeShopService : ICofeeShopService
{
    private readonly ApplicationDbContext _db;
    public CofeeShopService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<CofeeShopDto>> GetAll()
    {
        var dtos = await _db.CofeeShops.Select(q => new CofeeShopDto
        {
            Id = q.Id,
            Address = q.Address,
            Name = q.Name,
            OpeningHours = q.OpenningHours,
        }).ToListAsync();

        return dtos;
    }
}
