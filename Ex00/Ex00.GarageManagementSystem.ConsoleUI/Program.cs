using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    using Ex00.GarageLogic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var garage = new Garage();
            Console.Out.WriteLine(string.Join(",", garage.GetSupportedVehicleTypes()));
            Console.Out.WriteLine(string.Join(",", garage.GetNecessaryArgsForType("Truck")));
            Console.Out.WriteLine(garage.AddAVehicleToGarage("555555", "666666", "bob", "Truck", new[] { "CAT", "555555", "Helmans", "false", "55", "10", "5" }));
            Console.Read();
        }
    }
}