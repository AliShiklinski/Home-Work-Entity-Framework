using Microsoft.EntityFrameworkCore;

public class Program
{
    public static async Task Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "CarDatabase")
            .Options;

        using var context = new ApplicationDbContext(options);

        var carService = new CarService(context);

        var cars = await carService.GetCarsAsync();

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Id} {car.BrandName} {car.ModelName} {car.MaxSpeed} {car.FuelTankCapacity} {car.Power} {car.DoorCount} Colors: {string.Join(", ", car.Colors)}");
        }
    }
}
