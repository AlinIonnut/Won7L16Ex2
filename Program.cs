using Microsoft.EntityFrameworkCore;
using Won7L16E2.Data;
using Won7L16E2.Models;

Seed();
OrderCars();

int FordId = AddCar("Focus", "Ford", 2012, "TSDC1247643");
Console.WriteLine($"The id of the car that was added is: {FordId}");

static void Seed()
{
    using var dbContext = new CarDbContext();

    dbContext.Cars.RemoveRange(dbContext.Cars);
    dbContext.SaveChanges();

    dbContext.Cars.Add(new Car { Name = "Logan", Brand = "Dacia", FabricationYear = 2006, VIN = "ASCV1234585" });
    dbContext.Cars.Add(new Car { Name = "Leon", Brand = "Seat", FabricationYear = 2012, VIN = "FNBC456372" });
    dbContext.Cars.Add(new Car { Name = "E39", Brand = "Bmw", FabricationYear = 1998, VIN = "NASC1234585" });
    dbContext.Cars.Add(new Car { Name = "Giulia", Brand = "Afla Romeo", FabricationYear = 2020, VIN = "XCVD1234768" });
    dbContext.Cars.Add(new Car { Name = "Superb", Brand = "Skoda", FabricationYear = 2007, VIN = "QWCV1237642" });
    dbContext.Cars.Add(new Car { Name = "Phaeton", Brand = "Vw", FabricationYear = 2012, VIN = "KMLG123736213" });

    dbContext.SaveChanges();
}


static void OrderCars()
{
    using var dbContext = new CarDbContext();

    var cars = dbContext.Cars.OrderByDescending(c => c.FabricationYear).ToList();

    foreach(var car in cars)
    {
        Console.WriteLine($"{car.Brand},{car.Name}, {car.FabricationYear}, {car.VIN}");
    }
}

static int AddCar(string name, string brand, int fabricationYear, string vin)
{
    using var dbContext = new CarDbContext();

    var newCar = new Car
    {
        Name = name,
        Brand = brand,
        FabricationYear = fabricationYear,
        VIN = vin
    };

    dbContext.Cars.Add(newCar);
    dbContext.SaveChanges();

    return newCar.Id;
}


