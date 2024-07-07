using Microsoft.EntityFrameworkCore;

public class CarService
{
    private readonly ApplicationDbContext _context;

    public CarService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CarDto>> GetCarsAsync()
    {
        return await _context.Cars
            .AsNoTracking()
            .Include(c => c.Model)
            .ThenInclude(m => m.Brand)
            .Include(c => c.CarColors)
            .ThenInclude(cc => cc.Color)
            .Select(c => new CarDto
            {
                Id = c.Id,
                BrandName = c.Model.Brand.Name,
                ModelName = c.Model.Name,
                MaxSpeed = c.MaxSpeed,
                FuelTankCapacity = c.FuelTankCapacity,
                Power = c.Power,
                DoorCount = c.DoorCount,
                Colors = c.CarColors.Select(cc => cc.Color.Name).ToList()
            })
            .ToListAsync();
    }
}