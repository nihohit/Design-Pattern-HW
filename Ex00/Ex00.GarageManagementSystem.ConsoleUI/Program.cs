using System;

namespace Ex00.GarageManagementSystem.ConsoleUI
{
    using Ex00.GarageLogic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Out.WriteLine(string.Join(",", new Garage().GetVehicleTypes()));
            Console.Out.WriteLine(string.Join(",", new Garage().GetNecessaryArgsForType("Truck")));
            Console.Read();
        }
    }
}